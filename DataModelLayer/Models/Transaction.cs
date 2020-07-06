using System;
using System.Collections.Generic;
using System.Text;

namespace DataModelLayer.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int WalletId { get; set; }
        public decimal Ammount { get; set; }
        public string Type { get; set; }
        public string Detail { get; set; }

    }
}
