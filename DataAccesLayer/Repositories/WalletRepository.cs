using DataAccesLayer.Config;
using DataModelLayer.Models;
using DataModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccesLayer.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DataBaseContext _context;

        public WalletRepository(DataBaseContext contex)
        {
            _context = contex;
        }

        public decimal GetBalance(string clientId)
        {
            var currentBalance = _context.Set<Wallet>().FirstOrDefault(x => x.ClientId == clientId).CurrentBalace;
            return currentBalance;
        }

        public Wallet GetWallet(int walletId)
        {
            Wallet wallet = _context.Set<Wallet>().FirstOrDefault(x => x.WalletId == walletId);
            return wallet;
        }

        public Wallet GetWalletByClient(string clientId)
        {
            Wallet wallet = _context.Set<Wallet>().FirstOrDefault(x => x.ClientId == clientId);
            return wallet;
        }
    }
}
