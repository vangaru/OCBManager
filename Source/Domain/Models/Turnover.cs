namespace OCBManager.Domain.Models
{
    public class Turnover
    {
        private string? _id;

        public string Id
        {
            get => _id ?? throw new ApplicationException("Turnover.Id");
            set => _id = value;
        }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }
    }
}