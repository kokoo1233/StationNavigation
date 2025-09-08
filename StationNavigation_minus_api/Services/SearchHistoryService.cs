// 파일: Services/SearchHistoryService.cs (이 내용으로 전체를 덮어쓰세요)

using Microsoft.EntityFrameworkCore;
using StationNavigation.Data;
using StationNavigation.Models;
using System.Threading.Tasks;

namespace StationNavigation.Services
{
    public class SearchHistoryService : ISearchHistoryService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public SearchHistoryService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task AddHistoryAsync(int departureId, int arrivalId)
        {
            using var context = _contextFactory.CreateDbContext();
            var history = new SearchHistory
            {
                DepartureLocationId = departureId,
                ArrivalLocationId = arrivalId
            };
            context.SearchHistories.Add(history);
            await context.SaveChangesAsync();
        }
    }
}
