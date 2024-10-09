using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewNotificationMicroservice.Domain.Entities;
using NewNotificationMicroservice.Domain.ValueObjects;

namespace NewNotificationMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Text)
                .HasConversion(
                    o => o.Value,
                    s => new MessageText(s))
                .IsRequired();

            builder.Property(x => x.Direction)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .IsRequired();

            builder.HasOne(x => x.Type)
                .WithMany()
                .IsRequired();

            builder.Navigation(x => x.Type)
                .AutoInclude();
        }
    }
}
