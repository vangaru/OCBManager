namespace OCBManager.Domain.Models
{
    public class Bill
    {
        private string? _id;
        private int? _billNumber;
        private IncomingBalance? _incomingBalance;
        private OutgoingBalance? _outgoingBalance;
        private Turnover? _turnover;
        private BillClass? _billClass;
        private TurnoverSheet? _turnoverSheet;
        private string? _incomingBalanceId;
        private string? _outgoingBalanceId;
        private string? _turnoverId;
        private string? _billClassId;
        private string? _turnoverSheetId;

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

        public string IncomingBalanceId
        {
            get => _incomingBalanceId ?? throw new ApplicationException("Bill.IncomingBalanceId is not defined");
            set => _incomingBalanceId = value;
        }

        public IncomingBalance IncomingBalance
        {
            get => _incomingBalance ?? throw new ApplicationException("Bill.IncomingBalance is not defined");
            set => _incomingBalance = value;
        }

        public string OutgoingBalanceId
        {
            get => _outgoingBalanceId ?? throw new ApplicationException("Bill.OutgoingBalanceId is not defined");
            set => _outgoingBalanceId = value;
        }

        public OutgoingBalance OutgoingBalance
        {
            get => _outgoingBalance ?? throw new ApplicationException("Bill.OutgoingBalance is not defined");
            set => _outgoingBalance = value;
        }

        public string TurnoverId
        {
            get => _turnoverId ?? throw new ApplicationException("Bill.TurnoverId is not defined.");
            set => _turnoverId = value;
        }

        public Turnover Turnover
        {
            get => _turnover ?? throw new ApplicationException("Bill.Turnover is not defined.");
            set => _turnover = value;
        }

        public string BillClassId
        {
            get => _billClassId ?? throw new ApplicationException("Bill.BillClassId is not defined.");
            set => _billClassId = value;
        }

        public BillClass BillClass
        {
            get => _billClass ?? throw new ApplicationException("Bill.BillClass is not defined.");
            set => _billClass = value;
        }

        public string TurnoverSheetId
        {
            get => _turnoverSheetId ?? throw new ApplicationException("Bill.TurnoverSheetId is not defined");
            set => _turnoverSheetId = value;
        }

        public TurnoverSheet TurnoverSheet
        {
            get => _turnoverSheet ?? throw new ApplicationException("Bill.TurnoverSheet is not defined");
            set => _turnoverSheet = value;
        }
    }
}