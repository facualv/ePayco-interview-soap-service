using DataAccesLayer.Repositories;
using DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    class WalletService
    {
        #region Fields

        private readonly WalletRepository _walletRepository;

        #endregion

        #region Props

        #endregion

        #region Constructors

        public WalletService(WalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }


        #endregion

        #region Method

        public decimal GetCurrentBalance(string clientId, string phone)
        {

            return _walletRepository.GetCurrentBalance(clientId);
        }

        #endregion
    }
}
