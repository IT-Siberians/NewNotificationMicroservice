using FluentValidation;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NewNotificationMicroservice.Application.Services;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Application.Services.Mapper;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction;
using NewNotificationMicroservice.Domain.Repositories.Abstractions;
using NewNotificationMicroservice.Infrastructure.EntityFramework;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using NewNotificationMicroservice.Infrastructure.MediatR.Handlers;
using NewNotificationMicroservice.Infrastructure.Queues.Implementations.MassTransit.Consumers;
using NewNotificationMicroservice.Infrastructure.Queues.Implementations.MassTransit.Producers;
using NewNotificationMicroservice.Infrastructure.Queues.Implementations.RabbitMQ.Mapper;
using NewNotificationMicroservice.Infrastructure.Queues.Implementations.RabbitMQ.Services;
using NewNotificationMicroservice.Infrastructure.RabbitMQ;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.Abstraction;
using NewNotificationMicroservice.Infrastructure.Repositories.Implementations.Ef;
using NewNotificationMicroservice.Web.Helpers;
using NewNotificationMicroservice.Web.Mapper;
using Otus.QueueDto.Email;
using Otus.QueueDto.Lot;
using Otus.QueueDto.Notification;
using Otus.QueueDto.User;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var dbConnectionString = builder.Configuration[nameof(ApplicationDbContext).ToUpper()];

if (string.IsNullOrEmpty(dbConnectionString))
{
    throw new InvalidOperationException("Connection string for ApplicationDbContext is not configured.");
}

var rmqConnectionString = builder.Configuration[nameof(RabbitMqConfig).ToUpper()];

if (string.IsNullOrEmpty(rmqConnectionString))
{
    throw new InvalidOperationException("Connection string for RabbitMqConfig is not configured.");
}

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Notification API",
                        Description = "The Notification API for managing message types, templates, and viewing the log of sent messages."
                    });
                });

builder.Services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options.UseNpgsql(dbConnectionString);
                });

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddAutoMapper(typeof(QueueProfile), typeof(ApplicationProfile), typeof(PresentationProfile));

builder.Services.Configure<RabbitMqConfig>(builder.Configuration.GetSection(nameof(RabbitMqConfig)));

builder.Services.AddScoped<ITypeApplicationService, MessageTypeService>();
builder.Services.AddScoped<IMessageTypeRepository, MessageTypeRepository>();

builder.Services.AddScoped<ITemplateApplicationService, MessageTemplateService>();
builder.Services.AddScoped<IMessageTemplateRepository, MessageTemplateRepository>();

builder.Services.AddScoped<IMessageApplicationService, MessageService>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();

builder.Services.AddScoped<IUserApplicationService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IBusQueueService, BusQueueService>();
builder.Services.AddScoped<IBusQueueRepository, BusQueueRepository>();

builder.Services.AddTransient<IProducerService<MessageEvent>, EmailMessageProducer>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddTransient<IRequestHandler<ConfirmationEmailCommand<ConfirmationEmailEvent>, bool>, ConfirmationEmailHandler>();
builder.Services.AddTransient<IRequestHandler<CreateUserCommand<CreateUserEvent>, bool>, CreateUserHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateUserCommand<UpdateUserEvent>, bool>, UpdateUserHandler>();
builder.Services.AddTransient<IRequestHandler<BidPerLotCommand<BidPerLotEvent>, bool>, BidPerLotHandler>();
builder.Services.AddTransient<IRequestHandler<WonLotCommand<WonLotEvent>, bool>, WonLotHandler>();

builder.Services.AddHealthChecks()
    .AddNpgSql(dbConnectionString)
    .AddRabbitMQ(rabbitConnectionString: rmqConnectionString)
    .AddDbContextCheck<ApplicationDbContext>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(typeof(ConfirmationEmailConsumer).Assembly);

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri(rmqConnectionString));
        cfg.ReceiveEndpoint($"{nameof(CreateUserEvent)}.Notify", e =>
        {
            e.ConfigureConsumer<CreateUserConsumer>(context);
        });

        cfg.ReceiveEndpoint($"{nameof(UpdateUserEvent)}.Notify", e =>
        {
            e.ConfigureConsumer<UpdateUserConsumer>(context);
        });
        cfg.ReceiveEndpoint($"{nameof(BidPerLotEvent)}.Notify", e =>
        {
            e.ConfigureConsumer<BidPerLotConsumer>(context);
        });

        cfg.ReceiveEndpoint($"{nameof(WonLotEvent)}.Notify", e =>
        {
            e.ConfigureConsumer<WonLotConsumer>(context);
        });
        cfg.ConfigureEndpoints(context);
        cfg.UseMessageRetry(r =>
        {
            r.Interval(3, TimeSpan.FromSeconds(10));
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

//app.UseHttpsRedirection();

app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseAuthorization();

app.MigrateDatabase<ApplicationDbContext>();

app.MapControllers();

app.Run();
