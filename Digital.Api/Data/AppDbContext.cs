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
        public DbSet<DeliveryDetail> DeliveryDetails { get; set; }
        public DbSet<SubGst> SubGsts { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankDetail> BankDetails { get; set; }

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

            modelBuilder.Entity<CompanyGst>().HasData(
                new CompanyGst { GstNumber = "27AADCD1234A1Z1", CompanyName = "DIGITAL NEW ENTERPRISES", StateName = "Maharashtra", MobileNumber = "9876543210", Email = "contact@digital.com" },
                new CompanyGst { GstNumber = "27BBBDD4321B1Z2", CompanyName = "TECH SOLUTIONS LTD", StateName = "Karnataka", MobileNumber = "9988776655", Email = "info@techsolutions.com" },
                new CompanyGst { GstNumber = "27CCCCD9999C1Z3", CompanyName = "GLOBAL LOGISTICS CORP", StateName = "Gujarat", MobileNumber = "9123456789", Email = "support@global.com" }
            );

            modelBuilder.Entity<Bank>().HasData(
                new Bank { Id = 1, BankName = "STATE BANK OF INDIA", Description = "SBI" },
                new Bank { Id = 2, BankName = "HDFC BANK", Description = "HDFC" },
                new Bank { Id = 3, BankName = "ICICI BANK", Description = "ICICI" },
                new Bank { Id = 4, BankName = "CANARA BANK", Description = "CANARA" }
            );
        }
    }
}
