using Microsoft.Extensions.Options;
using NewNotificationMicroservice.Common.Infrastructure.Queues;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction;
using NewNotificationMicroservice.Domain.Entities.Enums;
using NewNotificationMicroservice.Infrastructure.RabbitMQ;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace NewNotificationMicroservice.Infrastructure.Queues.Implementations.RabbitMQ
{
    public class RMQProducerService : IProducerService
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly RabbitMqConfig _rabbitMqConfig;

        public RMQProducerService(IOptions<RabbitMqConfig> rabbitMqConfig)
        {
            _rabbitMqConfig = rabbitMqConfig.Value;

            _connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(_rabbitMqConfig.ConnectionString)
            };
        }

        public void SendMessage(SendMessage message, Direction direction)
        {
            var messageString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(messageString);

            using var connection = _connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _rabbitMqConfig.ProducerQueuesDictionary[direction], durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.BasicPublish(exchange: "", routingKey: _rabbitMqConfig.ProducerQueuesDictionary[direction], basicProperties: null, body: body);
        }
    }
}
