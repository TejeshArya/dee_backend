using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string? EmployeeId { get; set; } // e.g., DEE300426132

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int? DesignationOfficerId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public DesignationOfficer? DesignationOfficer { get; set; }

        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";

        public string? TemporaryPassword { get; set; }
        public string? AnnualSalary { get; set; }
        public string? Qualification { get; set; }
        public string? Remarks { get; set; }

        // ── Personal Details ──────────────────────────
        public string? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? BloodGroup { get; set; }
        public string? Religion { get; set; }
        public string? Category { get; set; }
        public string? MobileNumber { get; set; }
        public string? AlternateNumber { get; set; }
        public string? Designation { get; set; }
        public string? DateOfJoining { get; set; }

        // ── Address ───────────────────────────────────
        public string? CurrentAddress { get; set; }
        public string? PermanentAddress { get; set; }

        // ── Government IDs ────────────────────────────
        public string? AadharNumber { get; set; }
        public string? PanNumber { get; set; }
        public string? UanNumber { get; set; }
        public string? EsicNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string? PassportValidUpto { get; set; }
        public string? PvcNumber { get; set; }
        public string? PvcValidUpto { get; set; }

        // ── Bank Details ──────────────────────────────
        public string? BankName { get; set; }
        public string? AccountNumber { get; set; }
        public string? IfscCode { get; set; }
        public string? BranchName { get; set; }
        public string? AccountType { get; set; }

        // ── Emergency Contact ─────────────────────────
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? EmergencyContactRelation { get; set; }

        // ── Nominee ───────────────────────────────────
        public string? NomineeName { get; set; }
        public string? NomineeRelation { get; set; }
        public string? NomineeDOB { get; set; }

        // ── Family Members (navigation) ───────────────
        public ICollection<EmployeeFamilyMember>? FamilyMembers { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public string? ApprovedBy { get; set; }
    }
}
