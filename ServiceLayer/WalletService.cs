using DataAccesLayer.Repositories;
using DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public class WalletService
    {
        private readonly WalletRepository _walletRepository;
        public WalletService(WalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public decimal GetBalance(string clientId)
        {
            return _walletRepository.GetBalance(clientId);
        }

        public Wallet GetWalletByClientId(string clientId)
        {
            return _walletRepository.GetWalletByClient(clientId);
        }
    }
}
