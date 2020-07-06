using DataAccesLayer.Config;
using DataModelLayer.Interfaces;
using DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataBaseContext _context;
        public TransactionRepository(DataBaseContext contex)
        {
            _context = contex;
        }

        public void CreateTransaction(Transaction transaction)
        {
            _context.Set<Transaction>().Add(transaction);
            _context.SaveChanges();
        }
    }
}
