using Microsoft.EntityFrameworkCore;
using Digital.Api.Models;

namespace Digital.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CompanyGst> CompanyGsts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data if needed
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "P & P" },
                new Department { Id = 2, Name = "CIVIL DEPARTMENT" },
                new Department { Id = 3, Name = "IT" }
            );

            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "VISAKHAPATNAM" },
                new Location { Id = 2, Name = "JAMNAGAR" }
            );
        }
    }
}
