namespace OCBManager.Domain.Models
{
    public class Bill : BillsSummaryBase
    {
        private int? _billNumber;
        private BillClass? _billClass;

        public int Id { get; set; }

        public int BillNumber
        {
            get => _billNumber ?? throw new ApplicationException("Bill.BillNumber is not defined");
            set => _billNumber = value;
        }

        public int BillClassId { get; set; }

        public BillClass BillClass
        {
            get => _billClass ?? throw new ApplicationException("Bill.BillClass is not defined.");
            set => _billClass = value;
        }
    }
}