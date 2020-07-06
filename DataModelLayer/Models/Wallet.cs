using System;
using System.Collections.Generic;
using System.Text;

namespace DataModelLayer.Models
{
    public class Wallet
    {
        public int WalletId { get; set; }
        public string ClientId { get; set; }
        public decimal CurrentBalace { get; set; }
    }
}
