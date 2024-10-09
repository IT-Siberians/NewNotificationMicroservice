using NewNotificationMicroservice.Domain.Entities.Base;
using NewNotificationMicroservice.Domain.Entities.Enums;
using NewNotificationMicroservice.Domain.ValueObjects;

namespace NewNotificationMicroservice.Domain.Entities
{
    /// <summary>
    /// Шаблон сообщения
    /// </summary>
    public class MessageTemplate : IModifyEntity<Guid>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        public MessageType Type { get; private set; }

        /// <summary>
        /// Язык шаблона
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Текс шаблона сообщений
        /// </summary>
        public Template Template { get; private set; }

        /// <summary>
        /// Статус удаления шааблона
        /// </summary>
        public bool IsRemoved { get; private set; }

        /// <summary>
        /// Пользователь создавший шаблон сообщения
        /// </summary>
        public User CreatedByUser { get; }

        /// <summary>
        /// Дата создания шаблона сообщения
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Пользователь изменивший шаблон сообщения
        /// </summary>
        public User? ModifiedByUser { get; private set; }

        /// <summary>
        /// Дата изменения шаблона сообщения
        /// </summary>
        public DateTime? ModificationDate { get; private set; }

        /// <summary>
        /// Пустой конструктор для EF Core
        /// </summary>
#pragma warning disable CS8618
        protected MessageTemplate() { }
#pragma warning disable CS8618

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="type">тип сообщения</param>
        /// <param name="language">язык шаблона</param>
        /// <param name="template">текст шаблона сообщения</param>
        /// <param name="isRemoved">признак удаления типа сообщения</param>
        /// <param name="createdByUser">пользователь создавший шаблон сообщения</param>
        /// <param name="creationDate">дата и время создания шаблона сообщения</param>
        /// <param name="modifiedByUser">пользователь изменивший шаблон сообщения</param>
        /// <param name="modificationDate">дата и время изменения шаблона сообщения</param>
        public MessageTemplate(MessageType type, Language language, Template template, bool isRemoved, User createdByUser, DateTime creationDate, User? modifiedByUser, DateTime? modificationDate)
        {
            Type = type;
            Language = language;
            Template = template;
            IsRemoved = isRemoved;
            CreatedByUser = createdByUser;
            CreationDate = creationDate;
            ModifiedByUser = modifiedByUser;
            ModificationDate = modificationDate;
        }

        /// <summary>
        /// Обновление класса
        /// </summary>
        /// <param name="messageType">тип сообщения</param>
        /// <param name="language">язык шаблона</param>
        /// <param name="template">текст шаблона сообщения</param>
        /// <param name="isRemoved">признак удаления типа сообщения</param>
        /// <param name="modifiedByUser">пользователь изменивший шаблон сообщения</param>
        /// <param name="modificationDate">дата и время изменения шаблона сообщения</param>
        public void Update(MessageType messageType, Language language, Template template, bool isRemoved, User modifiedByUser, DateTime modificationDate)
        {
            Type = messageType;
            Language = language;
            Template = template;
            IsRemoved = isRemoved;
            ModifiedByUser = modifiedByUser;
            ModificationDate = modificationDate;
        }

        /// <summary>
        /// Деактивация "Удаление"
        /// </summary>
        /// <param name="modifiedByUser">пользователь изменивший шаблон сообщения</param>
        /// <param name="modificationDate">дата и время изменения шаблона сообщения</param>
        public void Delete(User modifiedByUser, DateTime modificationDate)
        {
            IsRemoved = true;
            ModifiedByUser = modifiedByUser;
            ModificationDate = modificationDate;
        }
    }
}
