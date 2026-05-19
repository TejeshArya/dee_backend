using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? CompanyGstNumber { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public CompanyGst? Company { get; set; }
        
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
