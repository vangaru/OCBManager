﻿using System.ComponentModel.DataAnnotations.Schema;

namespace OCBManager.Domain.Models
{
    public class Turnover
    {
        private string? _id;
        private string? _billId;
        private Bill? _bill;

        public string Id
        {
            get => _id ?? throw new ApplicationException("Turnover.Id");
            set => _id = value;
        }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Debit { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Credit { get; set; }

        public string BillId
        {
            get => _billId ?? throw new ApplicationException("Turnover.BillId is not defined.");
            set => _billId = value;
        }

        public Bill Bill
        {
            get => _bill ?? throw new ApplicationException("Turnover.Bill is not defined.");
            set => _bill = value;
        }
    }
}