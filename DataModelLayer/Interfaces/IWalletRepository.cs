using System;
using System.Collections.Generic;
using System.Text;

namespace DataModelLayer.Interfaces
{
    public interface IWalletRepository
    {
        decimal GetCurrentBalance(string clientId);
    }
}
