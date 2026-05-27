using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class EmployeeRequiredRule
    {
        [Key]
        public int Id { get; set; }

        // Step 1: Basic Info
        public bool FullName { get; set; } = true;
        public bool OfficialEmail { get; set; } = true;
        public bool EmployeeCode { get; set; } = false;
        public bool DateOfJoining { get; set; } = true;
        public bool Department { get; set; } = true;
        public bool Location { get; set; } = false;
        public bool Designation { get; set; } = true;
        public bool AnnualSalary { get; set; } = false;
        public bool CoreQualification { get; set; } = true;
        public bool Remarks { get; set; } = false;

        // Step 2: Personal Details
        public bool DateOfBirth { get; set; } = true;
        public bool Gender { get; set; } = true;
        public bool MaritalStatus { get; set; } = true;
        public bool BloodGroup { get; set; } = true;
        public bool Religion { get; set; } = false;
        public bool Category { get; set; } = true;
        public bool MobileNumber { get; set; } = true;
        public bool AlternateNumber { get; set; } = false;

        // Step 3: Address Details
        public bool CurrentAddress { get; set; } = true;
        public bool PermanentAddress { get; set; } = true;

        // Step 4: Govt IDs & Docs
        public bool Photo { get; set; } = true;
        public bool AadharNumber { get; set; } = true;
        public bool PanNumber { get; set; } = true;
        public bool UanNumber { get; set; } = false;
        public bool EsicNumber { get; set; } = false;
        public bool PassportNumber { get; set; } = false;
        public bool PvcNumber { get; set; } = false;

        // Step 5: Bank Details
        public bool BankDetails { get; set; } = true;

        // Step 6: Emergency & Nominee Details
        public bool EmergencyName { get; set; } = true;
        public bool EmergencyPhone { get; set; } = true;
        public bool EmergencyRelation { get; set; } = true;
        public bool NomineeDetails { get; set; } = false;
    }
}
