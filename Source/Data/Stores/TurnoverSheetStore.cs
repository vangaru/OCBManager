using Microsoft.EntityFrameworkCore;
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

        public async Task<List<TurnoverSheet>> GetTurnoverSheetAsync()
        {
            return await _context.TurnoverSheets.ToListAsync();
        }

        public async Task<TurnoverSheet> GetTurnoverSheetAsync(int id)
        {
            return new TurnoverSheet();
        }
    }
}