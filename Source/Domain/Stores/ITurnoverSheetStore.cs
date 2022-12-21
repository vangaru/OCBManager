using OCBManager.Domain.Models;

namespace OCBManager.Domain.Stores
{
    public interface ITurnoverSheetStore
    {
        public Task AddAsync(TurnoverSheet turnoverSheet);
        public Task<List<TurnoverSheet>> GetTurnoverSheetAsync();
        public Task<TurnoverSheet> GetTurnoverSheetAsync(int id);
    }
}
