namespace OCBManager.Domain.Models
{
    public class BillClass : BillsSummaryBase
    {
        private string? _name;
        private TurnoverSheet? _turnoverSheet;

        public int Id { get; set; }

        public string Name
        {
            get => _name ?? throw new ApplicationException("BillClass.Name is not defined.");
            set => _name = value;
        }

        public List<Bill> Bills { get; set; } = new();

        public int TurnoverSheetId { get; set; }

        public TurnoverSheet TurnoverSheet
        {
            get => _turnoverSheet ?? throw new ApplicationException("BillClass.TurnoverSheet is not defined");
            set => _turnoverSheet = value;
        }
    }
}