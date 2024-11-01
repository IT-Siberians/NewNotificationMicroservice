using NewNotificationMicroservice.Domain.Entities.Base;
using NewNotificationMicroservice.Domain.Entities.Enums;
using NewNotificationMicroservice.Domain.ValueObjects;

namespace NewNotificationMicroservice.Domain.Entities
{
    /// <summary>
    /// Представляет пользователя в системе уведомлений.
    /// </summary>
    public class User : IEntity<Guid>
    {
        /// <summary>
        /// Получает идентификатор пользователя.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Получает имя пользователя.
        /// </summary>
        public Username Username { get; }

        /// <summary>
        /// Получает ФИО пользователя.
        /// </summary>
        public FullName FullName { get; private set; }

        /// <summary>
        /// Получает адрес электронной почты пользователя.
        /// </summary>
        public Email Email { get; private set; }

        /// <summary>
        /// Язык шаблона
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Получает дату и время создания пользователя.
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Пустой конструктор для EF Core
        /// </summary>
#pragma warning disable CS8618
        protected User() { }
#pragma warning disable CS8618

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="User"/> с указанными параметрами.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="fullName">Имя пользователя.</param>
        /// <param name="email">Адрес электронной почты пользователя.</param>
        /// <param name="language">Язык пользователя.</param>
        public User(Guid id, Username username, FullName fullName, Email email, Language language)
        {
            Id = id;
            Username = username;
            FullName = fullName;
            Email = email;
            Language = language;
            CreationDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Обновление экземпляра класса <see cref="User"/> с указанными параметрами.
        /// </summary>
        /// <param name="fullName">Имя пользователя.</param>
        /// <param name="email">Адрес электронной почты пользователя.</param>
        /// <param name="language">Язык пользователя.</param>
        public void Update(FullName fullName, Email email, Language language)
        {
            FullName = fullName;
            Email = email;
            Language = language;
        }
    }
}
