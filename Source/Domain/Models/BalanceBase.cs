using System.ComponentModel.DataAnnotations.Schema;

namespace OCBManager.Domain.Models
{
    public abstract class BalanceBase
    {
        private string? _id;
        private string? _billId;
        private Bill? _bill;

        public string Id
        {
            get => _id ?? throw new ApplicationException($"{GetType().Name} is not defined.");
            set => _id = value;
        }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Active { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Passive { get; set; }

        public string BillId
        {
            get => _billId ?? throw new ApplicationException($"{GetType().Name} is not defined.");
            set => _billId = value;
        }

        public Bill Bill
        {
            get => _bill ?? throw new ApplicationException($"{GetType().Name} is not defined.");
            set => _bill = value;
        }
    }
}
