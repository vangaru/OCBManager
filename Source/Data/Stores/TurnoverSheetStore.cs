using OCBManager.Data.Data;
using OCBManager.Domain.Models;
using OCBManager.Domain.Stores;

namespace OCBManager.Data.Stores
{
    public class TurnoverSheetStore : ITurnoverSheetStore
    {
        private readonly OCBContext _context;

        public TurnoverSheetStore(OCBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TurnoverSheet turnoverSheet)
        {
            _context.Add(turnoverSheet);
            await _context.SaveChangesAsync();
        }
    }
}
