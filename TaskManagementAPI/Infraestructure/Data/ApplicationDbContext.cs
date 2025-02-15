using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserTask> UserTasks { get; set; } = null!;
        public DbSet<SubTask> SubTaks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Tasks)
                .WithOne();

            modelBuilder.Entity<UserTask>()
                .HasMany(e => e.SubTasks)
                .WithOne();
        }
    }
}