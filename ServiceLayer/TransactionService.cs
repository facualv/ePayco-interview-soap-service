using DataAccesLayer.Repositories;
using DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public class TransactionService
    {
        private readonly TransactionRepository _transactionRepositoryy;
        public TransactionService(TransactionRepository transactionRepository)
        {
            _transactionRepositoryy = transactionRepository;
        }
        public void CreateTransaction(Transaction transaction)
        {
            _transactionRepositoryy.CreateTransaction(transaction);
        }
    }
}
