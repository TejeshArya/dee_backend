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
        public DbSet<EmployeeRequiredRule> EmployeeRequiredRules { get; set; }
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
        public DbSet<Wing> Wings { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<RoleAssignment> RoleAssignments { get; set; }
        public DbSet<SubLocation> SubLocations { get; set; }
        public DbSet<LocationHead> LocationHeads { get; set; }
        public DbSet<PostGrouping> PostGroupings { get; set; }
        public DbSet<PostGroupingItem> PostGroupingItems { get; set; }
        public DbSet<EmployeeFund> EmployeeFunds { get; set; }
        public DbSet<EmployeeProfileUpdateRequest> ProfileUpdateRequests { get; set; }
        public DbSet<EmployeeFamilyMember> EmployeeFamilyMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data if needed
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "HR", Description = "DSEC", Status = true, CreatedAt = new DateTime(2025, 12, 22, 5, 57, 0, DateTimeKind.Utc), CompanyGstNumber = "27AADCD1234A1Z1" },
                new Department { Id = 2, Name = "IT", Description = "DSEC", Status = true, CreatedAt = new DateTime(2025, 12, 22, 5, 57, 0, DateTimeKind.Utc), CompanyGstNumber = "27AADCD1234A1Z1" },
                new Department { Id = 3, Name = "SALES", Description = "DESCRIPTION", Status = true, CreatedAt = new DateTime(2025, 12, 22, 5, 58, 0, DateTimeKind.Utc), CompanyGstNumber = "27AADCD1234A1Z1" },
                new Department { Id = 4, Name = "R & D", Description = "RESEARCH AND DEVELOPMENT", Status = true, CreatedAt = new DateTime(2025, 12, 22, 5, 58, 0, DateTimeKind.Utc), CompanyGstNumber = "27AADCD1234A1Z1" },
                new Department { Id = 5, Name = "P & P", Description = "PLANNING AND PRODUCTION", Status = true, CreatedAt = new DateTime(2025, 12, 22, 5, 59, 0, DateTimeKind.Utc), CompanyGstNumber = "27AADCD1234A1Z1" },
                new Department { Id = 6, Name = "ACCOUNTS", Description = "ACCOUNTS", Status = true, CreatedAt = new DateTime(2025, 12, 22, 5, 59, 0, DateTimeKind.Utc), CompanyGstNumber = "27AADCD1234A1Z1" },
                new Department { Id = 7, Name = "CIVIL DEPARTMENT", Description = "CIVIL WORK", Status = true, CreatedAt = new DateTime(2026, 4, 4, 23, 32, 0, DateTimeKind.Utc), CompanyGstNumber = "27AADCD1234A1Z1" }
            );

            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "VISAKHAPATNAM", Description = "Main Office Location", CreatedAt = new DateTime(2025, 12, 19, 11, 0, 18, DateTimeKind.Utc) },
                new Location { Id = 2, Name = "KARWAR", Description = "DESC", CreatedAt = new DateTime(2025, 12, 24, 2, 42, 58, DateTimeKind.Utc) },
                new Location { Id = 3, Name = "MUMBAI", Description = "MUMBAI", CreatedAt = new DateTime(2025, 12, 30, 6, 40, 15, DateTimeKind.Utc) },
                new Location { Id = 4, Name = "KOLKATA", Description = "WEST BENGAL", CreatedAt = new DateTime(2026, 1, 2, 6, 1, 30, DateTimeKind.Utc) },
                new Location { Id = 5, Name = "JAMNAGAR", Description = "JAMNAGAR", CreatedAt = new DateTime(2026, 3, 31, 14, 26, 42, DateTimeKind.Utc) },
                new Location { Id = 6, Name = "KOCHIN", Description = "KOCHIN", CreatedAt = new DateTime(2026, 3, 31, 14, 28, 28, DateTimeKind.Utc) }
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

            modelBuilder.Entity<Wing>().HasData(
                new Wing { Id = 1, Name = "ELECTRICAL", Description = "DESC", Status = true, UserCount = 0, CreatedAt = new DateTime(2025, 12, 22, 5, 56, 0, DateTimeKind.Utc) },
                new Wing { Id = 2, Name = "CIVIL", Description = "DEC", Status = true, UserCount = 0, CreatedAt = new DateTime(2025, 12, 22, 5, 56, 0, DateTimeKind.Utc) }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, GroupId = 12, GroupName = "JUNIOR ENGINEER", Wing = "ELECTRICAL", Dept = "P & P", Title = "SOFTWARE DEVELOPER3", Desc = "DEVELOPER", Date = new DateTime(2026, 4, 30, 0, 0, 0, DateTimeKind.Utc) },
                new Post { Id = 2, GroupId = 15, GroupName = "TECHNICIAN", Wing = "CIVIL", Dept = "P & P", Title = "Welder", Desc = "Welder", Date = new DateTime(2026, 4, 13, 0, 0, 0, DateTimeKind.Utc) },
                new Post { Id = 3, GroupId = 14, GroupName = "ASSISTANT SUPERVISOR", Wing = "ELECTRICAL", Dept = "P & P", Title = "DEE HQ OFFICE ADMINISTRATOR", Desc = "DEE HQ OFFICE ADMINISTRATOR", Date = new DateTime(2026, 4, 4, 0, 0, 0, DateTimeKind.Utc) },
                new Post { Id = 4, GroupId = 15, GroupName = "TECHNICIAN", Wing = "ELECTRICAL", Dept = "P & P", Title = "ELECTRICAL TECHNICIAN", Desc = "ELECTRICAL TECHNICIAN", Date = new DateTime(2026, 4, 3, 0, 0, 0, DateTimeKind.Utc) }
            );

            modelBuilder.Entity<RoleAssignment>().HasData(
                new RoleAssignment { Id = 1, GroupId = 12, GroupName = "JUNIOR ENGINEER", PostId = 1, PostTitle = "SOFTWARE DEVELOPER3", Wing = "ELECTRICAL", Dept = "P & P", LocationId = 1, LocationName = "VISAKHAPATNAM", EmployeeId = 1, EmployeeName = "TEJESH GUDLA", EmployeeCode = "DEE300426132", Desc = "DEVELOPER", Date = new DateTime(2026, 4, 30, 0, 0, 0, DateTimeKind.Utc) },
                new RoleAssignment { Id = 2, GroupId = 15, GroupName = "TECHNICIAN", PostId = 2, PostTitle = "Welder", Wing = "CIVIL", Dept = "P & P", LocationId = 1, LocationName = "VISAKHAPATNAM", EmployeeId = 2, EmployeeName = "GANDIBOINA GOWRI PRASAD", EmployeeCode = "DEE130426131", Desc = "Welder", Date = new DateTime(2026, 4, 13, 0, 0, 0, DateTimeKind.Utc) },
                new RoleAssignment { Id = 3, GroupId = 14, GroupName = "ASSISTANT SUPERVISOR", PostId = 3, PostTitle = "DEE HQ OFFICE ADMINISTRATOR", Wing = "ELECTRICAL", Dept = "P & P", LocationId = 1, LocationName = "VISAKHAPATNAM", EmployeeId = 3, EmployeeName = "SAYAD SARFARAZ", EmployeeCode = "DEE040426129", Desc = "DEE HQ OFFICE ADMINISTRATIVE", Date = new DateTime(2026, 4, 4, 0, 0, 0, DateTimeKind.Utc) },
                new RoleAssignment { Id = 4, GroupId = 15, GroupName = "TECHNICIAN", PostId = 4, PostTitle = "ELECTRICAL INTEGRATION", Wing = "ELECTRICAL", Dept = "P & P", LocationId = 1, LocationName = "VISAKHAPATNAM", EmployeeId = 4, EmployeeName = "KANDREGULA KOTESWARA RAO", EmployeeCode = "DEE030426128", Desc = "desc", Date = new DateTime(2026, 4, 3, 0, 0, 0, DateTimeKind.Utc) }
            );

            modelBuilder.Entity<SubLocation>().HasData(
                new SubLocation { Id = 1, LocationId = 4, Name = "GRSE FOJ", Description = "GRSE FOJ", CreatedAt = new DateTime(2026, 4, 2, 0, 0, 0, DateTimeKind.Utc) },
                new SubLocation { Id = 2, LocationId = 1, Name = "INS DEGA BLD", Description = "AFLS MUSTERING POINT", CreatedAt = new DateTime(2026, 3, 28, 0, 0, 0, DateTimeKind.Utc) },
                new SubLocation { Id = 3, LocationId = 3, Name = "LION GATE", Description = "N/A", CreatedAt = new DateTime(2025, 12, 30, 0, 0, 0, DateTimeKind.Utc) }
            );

            // Configure unique index for LocationHead to satisfy one-head-per-location constraint
            modelBuilder.Entity<LocationHead>()
                .HasIndex(lh => lh.LocationId)
                .IsUnique();

            // Seed employees to map original mock location heads
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 101,
                    EmployeeId = "DEE010126115",
                    Name = "RANJAN YADAV",
                    Email = "ranjan.yadav@digital.com",
                    LocationId = 1,
                    Role = "Location Head",
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 3, 31, 13, 2, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 102,
                    EmployeeId = "DEE251225102",
                    Name = "ANUPAM KUMAR",
                    Email = "anupam.kumar@digital.com",
                    LocationId = 3,
                    Role = "Location Head",
                    Status = "Active",
                    CreatedAt = new DateTime(2025, 12, 30, 6, 40, 15, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 103,
                    EmployeeId = "DEE251225103",
                    Name = "SANJAY KUMAR MAHATO",
                    Email = "sanjay.mahato@digital.com",
                    LocationId = 5,
                    Role = "Location Head",
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 3, 31, 14, 26, 42, DateTimeKind.Utc)
                }
            );

            // Seed location head assignments
            modelBuilder.Entity<LocationHead>().HasData(
                new LocationHead { Id = 1, LocationId = 1, EmployeeId = 101, AssignedAt = new DateTime(2026, 3, 31, 13, 2, 0, DateTimeKind.Utc) },
                new LocationHead { Id = 2, LocationId = 3, EmployeeId = 102, AssignedAt = new DateTime(2026, 4, 1, 4, 39, 0, DateTimeKind.Utc) },
                new LocationHead { Id = 3, LocationId = 2, EmployeeId = 102, AssignedAt = new DateTime(2026, 4, 1, 4, 39, 0, DateTimeKind.Utc) },
                new LocationHead { Id = 4, LocationId = 5, EmployeeId = 103, AssignedAt = new DateTime(2026, 4, 3, 4, 0, 0, DateTimeKind.Utc) },
                new LocationHead { Id = 5, LocationId = 4, EmployeeId = 101, AssignedAt = new DateTime(2026, 4, 3, 4, 15, 0, DateTimeKind.Utc) }
            );

            // Seed starting employee funds
            modelBuilder.Entity<EmployeeFund>().HasData(
                new EmployeeFund
                {
                    Id = 1,
                    EmployeeId = 1,
                    Amount = 15000.00m,
                    GivenDate = new DateTime(2026, 4, 15, 0, 0, 0, DateTimeKind.Utc),
                    Purpose = "Office Supplies & Development Kit Reimbursement",
                    Status = "Approved",
                    RefNo = "FT-948274",
                    RecordedBy = "AMANTU",
                    CreatedAt = new DateTime(2026, 4, 15, 10, 0, 0, DateTimeKind.Utc)
                },
                new EmployeeFund
                {
                    Id = 2,
                    EmployeeId = 3,
                    Amount = 8500.00m,
                    GivenDate = new DateTime(2026, 5, 10, 0, 0, 0, DateTimeKind.Utc),
                    Purpose = "Client Site Travel & Accommodation Allowance",
                    Status = "Released",
                    RefNo = "FT-201847",
                    RecordedBy = "AMANTU",
                    CreatedAt = new DateTime(2026, 5, 10, 11, 30, 0, DateTimeKind.Utc)
                },
                new EmployeeFund
                {
                    Id = 3,
                    EmployeeId = 102,
                    Amount = 12000.00m,
                    GivenDate = new DateTime(2026, 5, 18, 0, 0, 0, DateTimeKind.Utc),
                    Purpose = "Technical Certification Fee Reimbursement",
                    Status = "Pending",
                    RefNo = "FT-583921",
                    RecordedBy = "AMANTU",
                    CreatedAt = new DateTime(2026, 5, 18, 14, 15, 0, DateTimeKind.Utc)
                }
            );

            // Seed sample profile update requests (pending, for demonstration)
            modelBuilder.Entity<EmployeeProfileUpdateRequest>().HasData(
                new EmployeeProfileUpdateRequest
                {
                    Id = 1,
                    EmployeeId = 1,
                    FieldName = "Role",
                    OldValue = "JUNIOR ENGINEER",
                    NewValue = "SENIOR ENGINEER",
                    Status = "Pending",
                    RequestedAt = new DateTime(2026, 5, 19, 9, 0, 0, DateTimeKind.Utc)
                },
                new EmployeeProfileUpdateRequest
                {
                    Id = 2,
                    EmployeeId = 3,
                    FieldName = "Qualification",
                    OldValue = null,
                    NewValue = "B.Tech Civil Engineering",
                    Status = "Pending",
                    RequestedAt = new DateTime(2026, 5, 20, 11, 30, 0, DateTimeKind.Utc)
                },
                new EmployeeProfileUpdateRequest
                {
                    Id = 3,
                    EmployeeId = 102,
                    FieldName = "Email",
                    OldValue = "anupam.kumar@digital.com",
                    NewValue = "a.kumar@digital.com",
                    Status = "Pending",
                    RequestedAt = new DateTime(2026, 5, 21, 8, 0, 0, DateTimeKind.Utc)
                }
            );

            modelBuilder.Entity<EmployeeRequiredRule>().HasData(
                new EmployeeRequiredRule
                {
                    Id = 1,
                    FullName = true,
                    OfficialEmail = true,
                    EmployeeCode = false,
                    DateOfJoining = true,
                    Department = true,
                    Location = false,
                    Designation = true,
                    AnnualSalary = false,
                    CoreQualification = true,
                    Remarks = false,
                    DateOfBirth = true,
                    Gender = true,
                    MaritalStatus = true,
                    BloodGroup = true,
                    Religion = false,
                    Category = true,
                    MobileNumber = true,
                    AlternateNumber = false,
                    CurrentAddress = true,
                    PermanentAddress = true,
                    Photo = true,
                    AadharNumber = true,
                    PanNumber = true,
                    UanNumber = false,
                    EsicNumber = false,
                    PassportNumber = false,
                    PvcNumber = false,
                    BankDetails = true,
                    EmergencyName = true,
                    EmergencyPhone = true,
                    EmergencyRelation = true,
                    NomineeDetails = false
                }
            );
        }

    }
}
