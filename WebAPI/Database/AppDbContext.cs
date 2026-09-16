namespace WebAPI.Database
{
    using Microsoft.EntityFrameworkCore;
    using WebAPI.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .ToTable("Expense")
                .HasQueryFilter(exp => exp.Status);

            modelBuilder.Entity<Message>()
                .ToTable("Message")
                .HasQueryFilter(msg => msg.Status);

        }

    }
}
