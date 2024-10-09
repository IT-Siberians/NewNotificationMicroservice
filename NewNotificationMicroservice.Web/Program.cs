using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NewNotificationMicroservice.Application.Services;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Application.Services.Mapper;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction;
using NewNotificationMicroservice.Domain.Repositories.Abstractions;
using NewNotificationMicroservice.Infrastructure.EntityFramework;
using NewNotificationMicroservice.Infrastructure.MediatR;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using NewNotificationMicroservice.Infrastructure.MediatR.Handlers;
using NewNotificationMicroservice.Infrastructure.Queues.Implementations;
using NewNotificationMicroservice.Infrastructure.Queues.Implementations.RabbitMQ;
using NewNotificationMicroservice.Infrastructure.Queues.Implementations.RabbitMQ.Mapper;
using NewNotificationMicroservice.Infrastructure.Queues.Implementations.RabbitMQ.Services;
using NewNotificationMicroservice.Infrastructure.RabbitMQ;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.Abstraction;
using NewNotificationMicroservice.Infrastructure.Repositories.Implementations.Ef;
using NewNotificationMicroservice.Web.Helpers;
using NewNotificationMicroservice.Web.Mapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

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
                    var connectionString = builder.Configuration.GetConnectionString(nameof(ApplicationDbContext));

                    if (string.IsNullOrEmpty(connectionString))
                    {
                        throw new InvalidOperationException("Connection string for ApplicationDbContext is not configured.");
                    }

                    options.UseNpgsql(connectionString);
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

builder.Services.AddScoped<IProducerService, RMQProducerService>();
builder.Services.AddHostedService<RMQConsumerService>();

builder.Services.AddScoped<NotificationControlService>(); // <- ������ ����� ����������

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<MessageQueueService>(); // <- �������� ����� ���, ���� ������� ����� NotificationControlService, �� � RMQConsumerService ����� ������ ���������

builder.Services.AddTransient<IRequestHandler<ConfirmationEmailCommand, bool>, ConfirmationEmailHandler>();
builder.Services.AddTransient<IRequestHandler<CreateUserCommand, bool>, CreateUserHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateUserCommand, bool>, UpdateUserHandler>();

//builder.Services.AddMediatR(typeof(MessageQueueService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MigrateDatabase<ApplicationDbContext>();

app.MapControllers();

app.Run();
