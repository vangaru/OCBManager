namespace OCBManager.Domain.Models
{
    public class TurnoverSheet : BillsSummaryBase
    {
        private string? _name;
        private string? _filePath;

        public int Id { get; set; }

        public string Name
        {
            get => _name ?? throw new ApplicationException("TurnoverSheet.Name is not defined.");
            set => _name = value;
        }

        public string FilePath
        {
            get => _filePath ?? throw new ApplicationException("TurnoverSheet.FilePath is not defined.");
            set => _filePath = value;
        }

        public List<BillClass> BillClasses { get; set; } = new();
    }
}
