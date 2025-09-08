using System.ComponentModel.DataAnnotations;

namespace StationNavigation.Models
{
    public class StationFloor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FloorName { get; set; } = string.Empty;
        
        public string? FloorPlanImagePath { get; set; } // 👈 평면도 이미지 경로 속성 추가

        public int FloorLevel { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
        public int StationId { get; set; }
        public Station Station { get; set; } = null!;
    }
}
