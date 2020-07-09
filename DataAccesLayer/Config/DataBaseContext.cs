using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataModelLayer.Models;

namespace DataAccesLayer.Config
{
    public class DataBaseContext: DbContext
    {
        private readonly String connectionString = "Server=localhost;Database=virtual_wallet_test;Uid=root;Pwd=lucero0405;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var client = modelBuilder.Entity<Client>();
            client.ToTable("client");
            client.HasKey("ClientId");
            client.Property(x => x.ClientId).HasColumnName("clientId");
            client.Property(x => x.Name).HasColumnName("name");
            client.Property(x => x.Phone).HasColumnName("phone");
            client.Property(x => x.Email).HasColumnName("email");
            client.Property(x => x.Password).HasColumnName("password");

            var wallet = modelBuilder.Entity<Wallet>();
            wallet.ToTable("wallet");
            wallet.HasKey("WalletId");
            wallet.Property(x => x.WalletId).HasColumnName("walletId");
            wallet.Property(x => x.CurrentBalace).HasColumnName("currentBalance");

            var transaction = modelBuilder.Entity<Transaction>();
            transaction.ToTable("transaction");
            transaction.Property(x => x.TransactionId).ValueGeneratedOnAdd().HasColumnName("transactionId");
            transaction.Property(x => x.WalletId).HasColumnName("walletId");
            transaction.Property(x => x.Ammount).HasColumnName("ammount");
            transaction.Property(x => x.Detail).HasColumnName("detail");

        }
    }
}

