using System.ComponentModel.DataAnnotations.Schema;

namespace OCBManager.Domain.Models
{
    public class Turnover
    {
        private Bill? _bill;

        public int Id { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Debit { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Credit { get; set; }

        public int BillId { get; set; }

        public Bill Bill
        {
            get => _bill ?? throw new ApplicationException("Turnover.Bill is not defined.");
            set => _bill = value;
        }
    }
}