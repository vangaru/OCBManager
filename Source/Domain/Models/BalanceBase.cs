using System.ComponentModel.DataAnnotations.Schema;

namespace OCBManager.Domain.Models
{
    public abstract class BalanceBase
    {
        private string? _billId;
        private Bill? _bill;

        public int Id { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Active { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Passive { get; set; }

        public int BillId { get; set; }

        public Bill Bill
        {
            get => _bill ?? throw new ApplicationException($"{GetType().Name} is not defined.");
            set => _bill = value;
        }
    }
}
