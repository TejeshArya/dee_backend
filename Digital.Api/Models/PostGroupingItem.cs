using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Digital.Api.Models
{
    public class PostGroupingItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PostGroupingId { get; set; }

        [JsonIgnore]
        public PostGrouping? PostGrouping { get; set; }

        [Required]
        public int PostId { get; set; }

        public Post? Post { get; set; }
    }
}
