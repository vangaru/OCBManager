namespace OCBManager.Domain.Models
{
    public class BillClass : BillsSummaryBase
    {
        private string? _id;
        private string? _name;

        public string Id
        {
            get => _id ?? throw new ApplicationException("BillClass.Id is not defined.");
            set => _id = value;
        }

        public string Name
        {
            get => _name ?? throw new ApplicationException("BillClass.Name is not defined.");
            set => _name = value;
        }

        public List<Bill> Bills { get; set; } = new();
    }
}