using Microsoft.EntityFrameworkCore;
using NewNotificationMicroservice.Domain.Entities;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.Models;

namespace NewNotificationMicroservice.Infrastructure.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MessageTemplate> Templates { get; set; }
        public DbSet<MessageType> Types { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BusQueue> BusQueues { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
