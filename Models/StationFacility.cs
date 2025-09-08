using System.ComponentModel.DataAnnotations;

namespace StationNavigation.Models
{
    public class StationFacility
    {
        [Key]
        public int Id { get; set; }
        
        public int StationId { get; set; }
        
        public int FloorId { get; set; }
        
        [Required]
        public string FacilityType { get; set; } = string.Empty;
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string? Location { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public Station Station { get; set; } = null!;
    }
}
