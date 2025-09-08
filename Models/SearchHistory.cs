using System;
using System.ComponentModel.DataAnnotations;

namespace StationNavigation.Models
{
    public class SearchHistory
    {
        [Key]
        public int Id { get; set; }

        public int DepartureLocationId { get; set; }
        public int ArrivalLocationId { get; set; }
        public DateTime SearchDate { get; set; } = DateTime.UtcNow;
    }
}
