using Microsoft.EntityFrameworkCore;
using OCBManager.Domain.Models;

namespace OCBManager.Data.Data
{
    public sealed class OCBContext : DbContext
    {
        public DbSet<Bill> Bills => Set<Bill>();
        public DbSet<BillClass> BillClasses => Set<BillClass>();
        public DbSet<TurnoverSheet> TurnoverSheets => Set<TurnoverSheet>();

        public OCBContext(DbContextOptions<OCBContext> options) : base(options)
        {
        }
    }
}
