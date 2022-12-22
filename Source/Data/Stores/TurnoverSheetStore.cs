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

        public async Task<int> AddAsync(TurnoverSheet turnoverSheet)
        {
            _context.Add(turnoverSheet);
            await _context.SaveChangesAsync();
            return turnoverSheet.Id;
        }

        public async Task<List<TurnoverSheet>> GetTurnoverSheetAsync()
        {
            return await _context.TurnoverSheets.ToListAsync();
        }

        public async Task<TurnoverSheet> GetTurnoverSheetAsync(int id)
        {
            return await _context.TurnoverSheets.Include(sheet => sheet.BillClasses)
                .ThenInclude(billClass => billClass.Bills).FirstAsync(sheet => sheet.Id == id);
        }
    }
}