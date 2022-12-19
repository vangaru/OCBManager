using System.ComponentModel.DataAnnotations.Schema;

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

        [Column(TypeName = "decimal(18, 2)")]
        public decimal IncomingBalanceActive 
        {
            get => _incomingBalanceActive ?? throw new ApplicationException($"{GetType().Name}.IncomingBalanceActive is not defined."); 
            set => _incomingBalanceActive = value; 
        }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal IncomingBalancePassive 
        {
            get => _incomingBalancePassive ?? throw new ApplicationException($"{GetType().Name}.IncomingBalancePassive is not defined.");
            set => _incomingBalancePassive = value;
        }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TurnoverDebit 
        { 
            get => _turnoverDebit ?? throw new ApplicationException($"{GetType().Name}.TurnoverDebit is not defined."); 
            set => _turnoverDebit = value; 
        }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TurnoverCredit 
        { 
            get => _turnoverCredit ?? throw new ApplicationException($"{GetType().Name}.TurnoverCredit is not defined."); 
            set => _turnoverCredit = value; 
        }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal OutgoingBalanceActive 
        {
            get => _outgoingBalanceActive ?? throw new ApplicationException($"{GetType().Name}.OutgoingBalanceActive is not defined.");
            set => _outgoingBalanceActive = value;
        }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal OutgoingBalancePassive 
        {
            get => _outgoingBalancePassive ?? throw new ApplicationException($"{GetType().Name}.OutgoingBalancePassive is not defined.");
            set => _outgoingBalancePassive = value;
        }
    }
}
