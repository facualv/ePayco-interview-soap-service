using DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModelLayer.Interfaces
{
    public interface IWalletRepository
    {
        decimal GetBalance(string clientId);

        Wallet GetWallet(int walletId);

        Wallet GetWalletByClient(string clientId);

    }
}
