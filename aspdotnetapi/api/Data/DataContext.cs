using aspdotnetapi.api.Models;
using Microsoft.EntityFrameworkCore;

namespace aspdotnetapi.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            // Configure the primary key, relationships, indices, or default values here
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);

            // Configure table name if different from DbSet property name
            modelBuilder.Entity<Category>().ToTable("Categories");

            // Example of configuring a relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // Setting default values or constraints
            modelBuilder.Entity<Category>()
                .Property(c => c.IsActive)
                .HasDefaultValue(true);
            */
        }

    }
}
