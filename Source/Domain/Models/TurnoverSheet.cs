namespace OCBManager.Domain.Models
{
    public class TurnoverSheet : BillsSummaryBase
    {
        private string? _id;
        private string? _name;
        private DateTime? _startOfThePeriod;
        private DateTime? _endOfThePeriod;

        public string Id
        {
            get => _id ?? throw new ApplicationException("TurnoverSheet.Id is not defined.");
            set => _id = value;
        }

        public string Name
        {
            get => _name ?? throw new ApplicationException("TurnoverSheet.Name is not defined.");
            set => _name = value;
        }

        public DateTime StartOfThePeriod
        {
            get => _startOfThePeriod ?? throw new ApplicationException("TurnoverSheet.StartOfThePeriod is not defined.");
            set => _startOfThePeriod = value;
        }

        public DateTime EndOfThePeriod
        {
            get => _endOfThePeriod ?? throw new ApplicationException("TurnoverSheet.EndOfThePeriod is not defined.");
            set => _endOfThePeriod = value;
        }
    }
}
