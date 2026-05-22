using System;
using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class LocationHead
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LocationId { get; set; }
        public Location? Location { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
