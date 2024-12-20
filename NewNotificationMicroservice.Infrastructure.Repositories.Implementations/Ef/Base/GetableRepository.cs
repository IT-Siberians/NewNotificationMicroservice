﻿using Microsoft.EntityFrameworkCore;
using NewNotificationMicroservice.Domain.Entities.Base;
using NewNotificationMicroservice.Domain.Repositories.Abstractions.Base.Parts;

namespace NewNotificationMicroservice.Infrastructure.Repositories.Implementations.Ef.Base
{
    /// <summary>
    /// Абстрактный класс репозитория для получения сущностей из БД.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип идентификатора сущности</typeparam>
    /// <param name="context">Контекст базы данных</param>
    public abstract class GetableRepository<TEntity, TKey>(DbContext context) : IGetableRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Получение всех сущностей
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <param name="asNoTracking">Флаг, указывающий на то, нужно ли отслеживать изменения сущностей</param>
        /// <returns>Коллекция сущностей</returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default, bool asNoTracking = false) => await (asNoTracking
            ? context.Set<TEntity>().AsNoTracking()
            : context.Set<TEntity>())
            .ToListAsync(cancellationToken);

        /// <summary>
        /// Получение сущности по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Сущность или null, если не найдена</returns>
        public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default) => await context
            .Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }
}
