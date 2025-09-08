using Microsoft.EntityFrameworkCore;
using StationNavigation.Data;
using StationNavigation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationNavigation.Services
{
    public class StationInfoService : IStationInfoService
    {
        private readonly ApplicationDbContext _context;
        
        public StationInfoService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<StationFloor>> GetFloorsByStationIdAsync(int stationId)
        {
            return await _context.StationFloors
                .Where(f => f.StationId == stationId)
                .OrderBy(f => f.FloorLevel)
                .ToListAsync();
        }
        
        public async Task<List<StationFacility>> GetFacilitiesByStationIdAsync(int stationId)
        {
            return await _context.StationFacilities
                .Where(f => f.StationId == stationId)
                .ToListAsync();
        }
    }
}
