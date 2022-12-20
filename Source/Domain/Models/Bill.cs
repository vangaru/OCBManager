﻿namespace OCBManager.Domain.Models
{
    public class Bill
    {
        private int? _billNumber;
        private IncomingBalance? _incomingBalance;
        private OutgoingBalance? _outgoingBalance;
        private Turnover? _turnover;
        private BillClass? _billClass;

        public int Id { get; set; }

        public int BillNumber
        {
            get => _billNumber ?? throw new ApplicationException("Bill.BillNumber is not defined");
            set => _billNumber = value;
        }

        public IncomingBalance IncomingBalance
        {
            get => _incomingBalance ?? throw new ApplicationException("Bill.IncomingBalance is not defined");
            set => _incomingBalance = value;
        }

        public OutgoingBalance OutgoingBalance
        {
            get => _outgoingBalance ?? throw new ApplicationException("Bill.OutgoingBalance is not defined");
            set => _outgoingBalance = value;
        }

        public Turnover Turnover
        {
            get => _turnover ?? throw new ApplicationException("Bill.Turnover is not defined.");
            set => _turnover = value;
        }

        public int BillClassId { get; set; }

        public BillClass BillClass
        {
            get => _billClass ?? throw new ApplicationException("Bill.BillClass is not defined.");
            set => _billClass = value;
        }
    }
}