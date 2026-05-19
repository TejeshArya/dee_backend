using Microsoft.EntityFrameworkCore;
using Digital.Api.Models;

namespace Digital.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Suppress the warning about pending model changes
            optionsBuilder.ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CompanyGst> CompanyGsts { get; set; }
        public DbSet<DeliveryDetail> DeliveryDetails { get; set; }
        public DbSet<SubGst> SubGsts { get; set; }
        public DbSet<DesignationOfficer> DesignationOfficers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankDetail> BankDetails { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationItem> QuotationItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<HsnCode> HsnCodes { get; set; }
        public DbSet<Denomination> Denominations { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SalesInvoiceItem> SalesInvoiceItems { get; set; }
        public DbSet<MasterData> MasterData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data if needed
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "P & P", CompanyGstNumber = "27AADCD1234A1Z1" },
                new Department { Id = 2, Name = "CIVIL DEPARTMENT", CompanyGstNumber = "27AADCD1234A1Z1" },
                new Department { Id = 3, Name = "IT", CompanyGstNumber = "27AADCD1234A1Z1" }
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

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "admin", DisplayName = "Administrator", Description = "Full system access" },
                new Role { Id = 2, Name = "DIRECTOR", DisplayName = "DIRECTOR", Description = "ADMIN" },
                new Role { Id = 3, Name = "MANAGING DIRECTOR", DisplayName = "MANAGING DIRECTOR", Description = "DESC" },
                new Role { Id = 4, Name = "HR", DisplayName = "HR", Description = "HR" },
                new Role { Id = 5, Name = "IT", DisplayName = "IT", Description = "IT DEPARTMENT" },
                new Role { Id = 6, Name = "SENIOR MANAGER", DisplayName = "SENIOR MANAGER", Description = "DESCRIPTION" },
                new Role { Id = 7, Name = "MANAGER", DisplayName = "MANAGER", Description = "DESCRIPTION" },
                new Role { Id = 8, Name = "ASSISTANT MANAGER", DisplayName = "ASSISTANT MANAGER", Description = "DESCRIPTION" },
                new Role { Id = 9, Name = "JUNIOR MANAGER", DisplayName = "JUNIOR MANAGER", Description = "DESCRIPTION" },
                new Role { Id = 10, Name = "SENIOR ENGINEER", DisplayName = "SENIOR ENGINEER", Description = "DESCRIPTION" },
                new Role { Id = 11, Name = "ENGINEER", DisplayName = "ENGINEER", Description = "DESCRIPTION" },
                new Role { Id = 12, Name = "JUNIOR ENGINEER", DisplayName = "JUNIOR ENGINEER", Description = "DESCRIPTION" },
                new Role { Id = 13, Name = "SUPERVISOR", DisplayName = "SUPERVISOR", Description = "DESCRIPTION" },
                new Role { Id = 14, Name = "ASSISTANT SUPERVISOR", DisplayName = "ASSISTANT SUPERVISOR", Description = "DESCRIPTION" },
                new Role { Id = 15, Name = "TECHNICIAN", DisplayName = "TECHNICIAN", Description = "DESCRIPTION" },
                new Role { Id = 16, Name = "HELPER", DisplayName = "HELPER", Description = "DESCRIPTION" },
                new Role { Id = 17, Name = "UNDER TRAINING", DisplayName = "UNDER TRAINING", Description = "DESCRIPTION" },
                new Role { Id = 18, Name = "User", DisplayName = "User", Description = "Default user access" }
            );
        }
    }
}
