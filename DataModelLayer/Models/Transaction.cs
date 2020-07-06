using System;
using System.Collections.Generic;
using System.Text;

namespace DataModelLayer.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public int WalletId { get; set; }

        public Decimal Ammount { get; set; }
        public String Type { get; set; }

        public String Detail { get; set; }

    }
}
