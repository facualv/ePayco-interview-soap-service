using DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModelLayer.Interfaces
{
    public interface ITransactionRepository
    {
        void CreateTransaction(Transaction transaction);
    }
}
