// 파일: Services/LocationService.cs (이 내용으로 전체를 덮어쓰세요)

using Microsoft.EntityFrameworkCore;
using StationNavigation.Data;
using StationNavigation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationNavigation.Services
{
    public class LocationService : ILocationService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public LocationService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Location>> GetAllActiveLocationsAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Locations.Where(l => l.IsActive).ToListAsync();
        }
    }
}
