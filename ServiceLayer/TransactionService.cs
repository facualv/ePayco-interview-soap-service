using DataAccesLayer.Repositories;
using DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    class TransactionService
    {

        #region Fields

        private readonly TransactionRepository _transactionRepositoryy;

        #endregion

        #region Props

        #endregion

        #region Constructors

        public TransactionService(TransactionRepository transactionRepository)
        {
            _transactionRepositoryy = transactionRepository;
        }
        #endregion

        #region Method

        public void CreateTransaction(Transaction transaction)
        {
            _transactionRepositoryy.CreateTransaction(transaction);
        }
        #endregion
    }
}
