﻿using NewNotificationMicroservice.Application.Models.BusQueue;
using NewNotificationMicroservice.Application.Services.Abstractions.Base;

namespace NewNotificationMicroservice.Infrastructure.RabbitMQ.Abstraction
{
    /// <summary>
    /// Интерефейс для сервиса работы с очередями сообщений
    /// </summary>
    public interface IBusQueueService : IServiceWithUpdateAndDelete<BusQueueModel, CreateBusQueueModel, UpdateBusQueueModel, DeleteBusQueueModel, Guid>
    {
        /// <summary>
        /// Получние типа по имени очереди сообщений
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BusQueueModel?> GetByNameAsync(string queueName, CancellationToken cancellationToken);
    }
}
