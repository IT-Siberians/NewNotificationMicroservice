using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction;
using NewNotificationMicroservice.Infrastructure.MediatR;
using NewNotificationMicroservice.Infrastructure.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace NewNotificationMicroservice.Infrastructure.Queues.Implementations.RabbitMQ
{
    public class RMQConsumerService : BackgroundService, IConsumerService, IDisposable
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly RabbitMqConfig _rabbitMqConfig;

        public RMQConsumerService(IOptions<RabbitMqConfig> rabbitMqConfig, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _rabbitMqConfig = rabbitMqConfig.Value;

            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_rabbitMqConfig.ConnectionString)
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            foreach (var queue in _rabbitMqConfig.ConsumerQueues)
            {
                bool result = false;

                _channel.QueueDeclare(
                    queue: queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    using var scope = _serviceScopeFactory.CreateScope();
                    var queueService = scope.ServiceProvider.GetRequiredService<MessageQueueService>();
                    result = await queueService.WorckAsync(message, queue, cancellationToken);

                    if (result)
                    {
                        _channel.BasicAck(ea.DeliveryTag, false);
                    }
                    else
                    {
                        _channel.BasicNack(ea.DeliveryTag, false, true);
                    }

                    await Task.CompletedTask;
                };

                _channel.BasicConsume(
                    queue: queue,
                    autoAck: false,
                    consumer: consumer);
            }

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken) => base.StopAsync(cancellationToken);

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _channel?.Dispose();
                _connection?.Dispose();
            }
        }
    }
}
