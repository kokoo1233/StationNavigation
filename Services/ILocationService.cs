// 파일 경로: Services/ILocationService.cs

using StationNavigation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationNavigation.Services
{
    public interface ILocationService
    {
        Task<List<Location>> GetAllActiveLocationsAsync();

	Task<List<Location>> GetActiveLocationsByStationIdAsync(int stationId);
    }
}
