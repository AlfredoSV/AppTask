using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTask.Data
{
    public class ApplicationDataDbContext : DbContext
    {
        public ApplicationDataDbContext(DbContextOptions<ApplicationDataDbContext> options) : base(options)
        {

        }

        public DbSet<TaskS> Tasks { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity
                <TaskS>().HasOne(t => t.Status)
                .WithMany()
                .HasForeignKey(t => t.StatusId);

            builder.Entity
                <TaskS>().HasOne(t => t.UserAssingned)
                .WithMany()
                .HasForeignKey(t => t.AssingTo);

            builder.Entity
                <TaskS>().HasOne(t => t.UserCreated)
                .WithMany()
                .HasForeignKey(t => t.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Status>().HasData([
                    new Status() { Id = Guid.Parse("e0a1e5e8-9271-4f57-8476-f30841c4d77e"), Name = "Pending" },
                    new Status() { Id = Guid.Parse("2d6b301f-7ec0-4373-b844-345ba3cb8672"), Name = "InProgress" },
                    new Status() { Id = Guid.Parse("4f2c5a27-3fc7-4b23-b68b-1c134a8c6fe1"), Name = "OnHold" },
                    new Status() { Id = Guid.Parse("66d7d8d1-6c4e-4966-b934-f7c45714a87b"), Name = "Completed" },
                    new Status() { Id = Guid.Parse("1e705b3a-7c2c-4957-a5a6-5e0a69b0219d"), Name = "Canceled" },
                    new Status() { Id = Guid.Parse("a3f2c89b-9115-4b84-92e1-8b8f4c6a2c3f"), Name = "Blocked" },
                ]
            );
            builder.Entity<User>().HasData([
                new User(){Id = Guid.Parse("71153bdf-54b6-408d-80a7-61d8e3a69673"), Name = "alfredosanchezverduzco@outlook.com"}
                ]
                );

            builder.Entity<TaskS>().HasData([
                new TaskS(){Id = Guid.Parse("31951ab6-101a-427d-9d9f-a613ad50601f"), Name = "First", Description="N/A", CreatedAt = DateTime.Parse("07/05/2025 07:10:55 a. m."), 
                CreatedBy = Guid.Parse("71153bdf-54b6-408d-80a7-61d8e3a69673"),
                AssingTo = Guid.Parse("71153bdf-54b6-408d-80a7-61d8e3a69673"),
                StatusId = Guid.Parse("e0a1e5e8-9271-4f57-8476-f30841c4d77e")}
                ]
                );
        }
    }
}
