namespace OCBManager.Domain.Models
{
    public abstract class BillsSummaryBase
    {
        private decimal? _incomingBalanceActive;
        private decimal? _incomingBalancePassive;
        private decimal? _turnoverDebit;
        private decimal? _turnoverCredit;
        private decimal? _outgoingBalanceActive;
        private decimal? _outgoingBalancePassive;

        public decimal IncomingBalanceActive 
        {
            get => _incomingBalanceActive ?? throw new ApplicationException($"{GetType().Name}.IncomingBalanceActive is not defined."); 
            set => _incomingBalanceActive = value; 
        }

        public decimal IncomingBalancePassive 
        {
            get => _incomingBalancePassive ?? throw new ApplicationException($"{GetType().Name}.IncomingBalancePassive is not defined.");
            set => _incomingBalancePassive = value;
        }

        public decimal TurnoverDebit 
        { 
            get => _turnoverDebit ?? throw new ApplicationException($"{GetType().Name}.TurnoverDebit is not defined."); 
            set => _turnoverDebit = value; 
        }

        public decimal TurnoverCredit 
        { 
            get => _turnoverCredit ?? throw new ApplicationException($"{GetType().Name}.TurnoverCredit is not defined."); 
            set => _turnoverCredit = value; 
        }

        public decimal OutgoingBalanceActive 
        {
            get => _outgoingBalanceActive ?? throw new ApplicationException($"{GetType().Name}.OutgoingBalanceActive is not defined.");
            set => _outgoingBalanceActive = value;
        }

        public decimal OutgoingBalancePassive 
        {
            get => _outgoingBalancePassive ?? throw new ApplicationException($"{GetType().Name}.OutgoingBalancePassive is not defined.");
            set => _outgoingBalancePassive = value;
        }
    }
}
