using System.ComponentModel.DataAnnotations;

namespace StationNavigation.Models
{
    public class Station
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Region { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        public ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}
