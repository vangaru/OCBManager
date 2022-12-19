using Microsoft.EntityFrameworkCore;
using OCBManager.Domain.Models;

namespace OCBManager.Data.Data
{
    public sealed class OCBContext : DbContext
    {
        public DbSet<IncomingBalance> IncomingBalances => Set<IncomingBalance>();
        public DbSet<OutgoingBalance> OutgoingBalances => Set<OutgoingBalance>();
        public DbSet<Bill> Bills => Set<Bill>();
        public DbSet<BillClass> BillClasses => Set<BillClass>();
        public DbSet<Turnover> Turnovers => Set<Turnover>();
        public DbSet<TurnoverSheet> TurnoverSheets => Set<TurnoverSheet>();

        public OCBContext(DbContextOptions<OCBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .HasOne(bill => bill.IncomingBalance)
                .WithOne(incomingBalance => incomingBalance.Bill)
                .HasForeignKey<IncomingBalance>(incomingBalance => incomingBalance.BillId);

            modelBuilder.Entity<Bill>()
                .HasOne(bill => bill.OutgoingBalance)
                .WithOne(outgoingBalance => outgoingBalance.Bill)
                .HasForeignKey<OutgoingBalance>(outgoingBalance => outgoingBalance.BillId);

            modelBuilder.Entity<Bill>()
                .HasOne(bill => bill.Turnover)
                .WithOne(turnover => turnover.Bill)
                .HasForeignKey<Turnover>(turnover => turnover.BillId);
        }

    }
}
