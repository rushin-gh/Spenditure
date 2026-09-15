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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .ToTable("Expense")
                .HasQueryFilter(exp => exp.Status);
        }
    }
}
