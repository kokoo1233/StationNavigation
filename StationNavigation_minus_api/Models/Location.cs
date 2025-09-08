using System.ComponentModel.DataAnnotations;

namespace StationNavigation.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Category { get; set; } = string.Empty; // 공공시설, 가게, 입/출구
        public int CategoryId { get; set; }

        public int StationId { get; set; }
        public Station Station { get; set; } = null!;
        
        public bool IsActive { get; set; } = true;
    }
}
