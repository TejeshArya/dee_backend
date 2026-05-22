using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class PostGrouping
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<PostGroupingItem> PostGroupingItems { get; set; } = new List<PostGroupingItem>();
    }
}
