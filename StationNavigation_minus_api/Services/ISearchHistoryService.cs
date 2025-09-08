using System.Threading.Tasks;

namespace StationNavigation.Services
{
    public interface ISearchHistoryService
    {
        Task AddHistoryAsync(int departureId, int arrivalId);
    }
}
