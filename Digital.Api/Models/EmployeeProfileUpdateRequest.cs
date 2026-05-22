using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Api.Models
{
    public class EmployeeProfileUpdateRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        /// <summary>
        /// Name of the employee field being changed (e.g. "Role", "Email", "Qualification", "AnnualSalary", "Remarks")
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string FieldName { get; set; } = string.Empty;

        /// <summary>
        /// Current (old) value of the field before the change
        /// </summary>
        [MaxLength(500)]
        public string? OldValue { get; set; }

        /// <summary>
        /// Requested new value for the field
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string NewValue { get; set; } = string.Empty;

        /// <summary>
        /// Status: Pending | Approved | Rejected
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Pending";

        /// <summary>
        /// Optional reason provided when rejecting the request
        /// </summary>
        [MaxLength(500)]
        public string? RejectionReason { get; set; }

        /// <summary>
        /// When the request was submitted by the employee
        /// </summary>
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// When the request was reviewed (approved or rejected)
        /// </summary>
        public DateTime? ReviewedAt { get; set; }

        /// <summary>
        /// Name of the HR admin who reviewed the request
        /// </summary>
        [MaxLength(100)]
        public string? ReviewedBy { get; set; }
    }
}
