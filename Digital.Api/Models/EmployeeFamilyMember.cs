using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Digital.Api.Models
{
    public class EmployeeFamilyMember
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [JsonIgnore]
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Relation { get; set; }

        public string? DateOfBirth { get; set; }

        /// <summary>Veg or Non-Veg</summary>
        [MaxLength(10)]
        public string? MealType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
