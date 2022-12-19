namespace OCBManager.Domain.Models
{
    public class Balance
    {
        private string? _id;

        public string Id
        {
            get => _id ?? throw new ApplicationException("Balance.Id is not defined.");
            set => _id = value;
        }

        public decimal Active { get; set; }

        public decimal Passive { get; set; }
    }
}
