using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewNotificationMicroservice.Domain.Entities;
using NewNotificationMicroservice.Domain.ValueObjects;

namespace NewNotificationMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.Username)
                .HasMaxLength(Username.MaxLength)
                .HasConversion(
                    v => v.Value,
                    v => new Username(v))
                .IsRequired();

            builder.Property(x => x.FullName)
                .HasMaxLength(FullName.MaxLength)
                .HasConversion(
                    v => v.Value,
                    v => new FullName(v))
                .IsRequired();

            builder.Property(x => x.Email)
                .HasConversion(
                    v => v.Value,
                    v => new Email(v))
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .IsRequired();

            builder.HasMany<MessageType>()
                .WithOne(x => x.CreatedByUser);

            builder.HasMany<MessageType>()
                .WithOne(x => x.ModifiedByUser);

            builder.HasMany<MessageTemplate>()
                .WithOne(x => x.CreatedByUser);

            builder.HasMany<MessageTemplate>()
                .WithOne(x => x.ModifiedByUser);

        }
    }
}
