using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DataAccesLayer.Config;
using DataAccesLayer.Repositories;
using DataModelLayer.Models;
using ServiceLayer;
using SoapServiceWebApp.DataTransferModel;

namespace SoapServiceWebApp
{
    /// <summary>
    /// Summary description for SoapWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SoapWebService : WebService
    {
        [WebMethod]
        public SignInResponse signIn(string clientId, string name, string phone, string email, string password)
        {
            SignInResponse response = new SignInResponse();

            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    ClientRepository userRepository = new ClientRepository(context);
                    ClientService clientService = new ClientService(userRepository);
                    Client newClient = new Client();

                    newClient.ClientId = clientId;
                    newClient.Name = name;
                    newClient.Phone = phone;
                    newClient.Email = email;
                    newClient.Password = password;

                    clientService.CreateClient(newClient);

                    newClient.Password = null;
                    response.Client = newClient;
                    response.Messagge = "Client Created Succesully";
                    response.StatusCode = 200;
                    return response;

                }
            }
            catch (Exception exeption)
            {
                response.Client = null;
                response.IsError = true;
                response.Messagge = exeption.Message;
                response.StatusCode = 500;
                return response;
            }
        }

        [WebMethod]
        public LoginResponse login(string email, string password)
        {
            LoginResponse response = new LoginResponse();

            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    ClientRepository userRepository = new ClientRepository(context);
                    ClientService clientService = new ClientService(userRepository);
                    Client currentClient = clientService.ValidateClientCredentials(email, password);

                    if (currentClient != null)
                    {
                        response.Messagge = "Client Logged Succesully";
                        response.Client = currentClient;
                        response.Client.Password = null;
                        response.StatusCode = 200;
                        return response;
                    }
                    else
                    {
                        response.Messagge = "Invalid Credentials";
                        response.StatusCode = 401;
                        return response;
                    }

                }
            }
            catch (Exception exeption)
            {
                response.IsError = true;
                response.Messagge = exeption.Message;
                response.Client = null;
                return response;
            }
        }

        [WebMethod]
        public CurrentBalanceBaseResponse getBalance(string clientId, string phone)
        {
            CurrentBalanceBaseResponse response = new CurrentBalanceBaseResponse();

            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    WalletRepository walletRepository = new WalletRepository(context);
                    WalletService walletService = new WalletService(walletRepository);

                    ClientRepository clientRepository = new ClientRepository(context);
                    ClientService clientService = new ClientService(clientRepository);

                    Client clientsExists = clientService.GetClientByIdAndPhone(clientId, phone);

                    if (clientsExists != null)
                    {
                        response.CurrentBalance = walletService.GetBalance(clientId);
                        response.Messagge = "Current Balance Retrieved Succesully";
                        response.StatusCode = 200;
                        return response;
                    }
                    else
                    {
                        response.CurrentBalance = walletService.GetBalance(clientId);
                        response.Messagge = "Invalid Credentials";
                        response.StatusCode = 401;
                        return response;
                    }
                }
            }
            catch (Exception exeption)
            {
                response.IsError = true;
                response.Messagge = exeption.Message;
                response.StatusCode = 500;
                return response;
            }
        }

        [WebMethod]
        public BaseResponse payment(string clientId, decimal ammount, string detail)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    ClientRepository clientRepository = new ClientRepository(context);
                    ClientService clientService = new ClientService(clientRepository);

                    WalletRepository walletRepository = new WalletRepository(context);
                    WalletService walletService = new WalletService(walletRepository);

                    TransactionRepository transactionRepository = new TransactionRepository(context);
                    TransactionService transactionService = new TransactionService(transactionRepository);

                    string clientsId = clientService.GetClientById(clientId).ClientId;
                    decimal currentBalance = walletService.GetBalance(clientId);
                    int walletId = walletService.GetWalletByClientId(clientId).WalletId;

                    //Checks if the money in the wallet is enough for the payment
                    if (currentBalance > ammount)
                    {
                        Transaction payment = new Transaction();
                        payment.WalletId = walletId;
                        payment.Ammount = ammount;
                        payment.Type = "pay";
                        payment.Detail = detail;
                        transactionService.CreateTransaction(payment);

                        response.Messagge = "Payment Succesull";
                        response.StatusCode = 200;
                        return response;
                    }
                    else
                    {
                        response.Messagge = "Your current balance is not enough to make the payment";
                        response.StatusCode = 403;
                        return response;
                    }
                }
            }
            catch (Exception exeption)
            {
                response.IsError = true;
                response.Messagge = exeption.Message;   
                response.StatusCode = 500;
                return response;
            }
        }
        
        [WebMethod]
        public BaseResponse recharge(string clientId, string phone, decimal ammount, string detail)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    ClientRepository clientRepository = new ClientRepository(context);
                    ClientService clientService = new ClientService(clientRepository);

                    WalletRepository walletRepository = new WalletRepository(context);
                    WalletService walletService = new WalletService(walletRepository);

                    TransactionRepository transactionRepository = new TransactionRepository(context);
                    TransactionService transactionService = new TransactionService(transactionRepository);

                    Client validClient = clientService.GetClientByIdAndPhone(clientId, phone);
                    decimal currentBalance = walletService.GetBalance(clientId);
                    int walletId = walletService.GetWalletByClientId(clientId).WalletId;

                    //Checks if credentials are valid 
                    if (validClient != null)
                    {
                        Transaction recharge = new Transaction();
                        recharge.WalletId = walletId;
                        recharge.Ammount = ammount;
                        recharge.Type = "recharge";
                        recharge.Detail = detail;
                        transactionService.CreateTransaction(recharge);

                        response.Messagge = "Recharge Completed Succesfully";
                        response.StatusCode = 200;

                        return response;
                    }
                    else
                    {
                        response.Messagge = "Invalid Credentials";
                        response.StatusCode = 401;
                        return response;
                    }   
                }
            }
            catch (Exception exeption)
            {
                response.IsError = true;
                response.Messagge = exeption.Message;
                response.StatusCode = 500;
                return response;
            }
        }

    }
}
