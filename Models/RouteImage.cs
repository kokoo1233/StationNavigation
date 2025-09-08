using System.ComponentModel.DataAnnotations;

namespace StationNavigation.Models
{
    public class RouteImage
    {
        [Key]
        public int Id { get; set; }
        
        public int FromLocationId { get; set; }
        public Location FromLocation { get; set; } = null!;
        
        public int ToLocationId { get; set; }
        public Location ToLocation { get; set; } = null!;
        
        [Required]
        public string ImagePath { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
    }
}
