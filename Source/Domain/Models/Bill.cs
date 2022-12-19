namespace OCBManager.Domain.Models
{
    public class Bill
    {
        private string? _id;
        private int? _billNumber;
        private Balance? _incomingBalance;
        private Balance? _outgoingBalance;
        private Turnover? _turnover;
        private BillClass? _billClass;

        public string Id
        {
            get => _id ?? throw new ApplicationException("Bill.Id is not defined");
            set => _id = value;
        }

        public int BillNumber
        {
            get => _billNumber ?? throw new ApplicationException("Bill.BillNumber is not defined");
            set => _billNumber = value;
        }

        public Balance IncomingBalance
        {
            get => _incomingBalance ?? throw new ApplicationException("Bill.IncomingBalance is not defined");
            set => _incomingBalance = value;
        }

        public Balance OutgoingBalance
        {
            get => _outgoingBalance ?? throw new ApplicationException("Bill.OutgoingBalance is not defined");
            set => _outgoingBalance = value;
        }

        public Turnover Turnover
        {
            get => _turnover ?? throw new ApplicationException("Bill.Turnover is not defined.");
            set => _turnover = value;
        }

        public BillClass BillClass
        {
            get => _billClass ?? throw new ApplicationException("Bill.BillClass is not defined.");
            set => _billClass = value;
        }
    }
}