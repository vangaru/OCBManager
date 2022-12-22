using OCBManager.Domain.Models;

namespace OCBManager.Domain.Stores
{
    public interface ITurnoverSheetStore
    {
        public Task<int> AddAsync(TurnoverSheet turnoverSheet);
        public Task<List<TurnoverSheet>> GetTurnoverSheetAsync();
        public Task<TurnoverSheet> GetTurnoverSheetAsync(int id);
    }
}
