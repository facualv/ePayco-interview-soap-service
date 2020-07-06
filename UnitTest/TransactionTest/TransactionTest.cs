using System;
using DataAccesLayer.Config;
using DataAccesLayer.Repositories;
using DataModelLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.TransactionTest
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod]
        public void CreateTransaction()
        {

            using (DataBaseContext context = new DataBaseContext())
            {
                TransactionRepository transactionRepository = new TransactionRepository(context);
                Transaction newTransaction = new Transaction();
                //newTransaction.TransactionId = 4;
                newTransaction.WalletId = 1;
                newTransaction.Ammount = 500;
                newTransaction.Type = "recharge";
                newTransaction.Detail = "Carga de 500";

                transactionRepository.CreateTransaction(newTransaction);

                Assert.IsTrue(newTransaction.Type.Contains("recharge"));
            }
        }
    }
}
