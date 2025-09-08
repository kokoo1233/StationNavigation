// 파일: Services/IStationInfoService.cs (이 내용으로 전체를 덮어쓰세요)

using StationNavigation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationNavigation.Services
{
    public interface IStationInfoService
    {
        Task<List<StationFloor>> GetFloorsByStationIdAsync(int stationId);
        Task<List<StationFacility>> GetFacilitiesByStationIdAsync(int stationId);
    }
}
