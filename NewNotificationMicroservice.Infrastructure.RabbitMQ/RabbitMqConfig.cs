using NewNotificationMicroservice.Domain.Entities.Enums;

namespace NewNotificationMicroservice.Infrastructure.RabbitMQ
{
    public class RabbitMqConfig
    {
        public required string ConnectionString { get; init; }
        public required string[] ProducerQueues { get; init; }
        public required string[] ConsumerQueues { get; init; }
        public Dictionary<Direction, string> ProducerQueuesDictionary
        {
            get
            {
                return Enum.GetValues(typeof(Direction)).Cast<Direction>().ToDictionary(d => d, d => ProducerQueues[(int)d - 1]);
            }
        }
    }
}
