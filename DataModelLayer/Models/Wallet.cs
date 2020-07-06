using System;
using System.Collections.Generic;
using System.Text;

namespace DataModelLayer.Models
{
    public class Wallet
    {
        public int WalletId { get; set; }

        public String ClientId { get; set; }

        public Decimal CurrentBalace { get; set; }

    }
}
