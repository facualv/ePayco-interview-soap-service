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
        public SignInResponse signup(string clientId, string name, string phone, string email, string password)
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
                    response.client = newClient;
                    response.message = "Client Created Succesully";
                    response.status = 200;
                    return response;

                }
            }
            catch (Exception exeption)
            {
                response.client = null;
                response.error = true;
                response.message = exeption.InnerException.Message;
                response.status = 500;
                return response;
            }
        }

        [WebMethod]
        public LoginResponse login(string email)
        {
            LoginResponse response = new LoginResponse();

            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    ClientRepository userRepository = new ClientRepository(context);
                    ClientService clientService = new ClientService(userRepository);
                    Client clientsExists = clientService.GetClientByEmail(email);

                    if (clientsExists != null)
                    {
                        response.message = "Client Exists";
                        response.client = clientsExists;
                        response.status = 200;
                        return response;
                    }
                    else
                    {
                        response.message = "The email provided is not registered in our database";
                        response.error = true;
                        response.status = 401;
                        return response;
                    }

                }
            }
            catch (Exception exeption)
            {
                response.error = true;
                response.message = exeption.InnerException.Message;
                response.client = null;
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
                    ClientRepository clientRepository = new ClientRepository(context);
                    ClientService clientService = new ClientService(clientRepository);

                    Client clientsExists = clientService.GetClientByIdAndPhone(clientId, phone);

                    if (clientsExists != null)
                    {
                        WalletRepository walletRepository = new WalletRepository(context);
                        WalletService walletService = new WalletService(walletRepository);

                        response.balance = walletService.GetBalance(clientId);
                        response.message = "Current Balance Retrieved Succesully";
                        response.status = 200;
                        return response;
                    }
                    else
                    {
                        response.message = "Invalid Credentials";
                        response.error = true;
                        response.status = 401;
                        return response;
                    }
                }
            }
            catch (Exception exeption)
            {
                response.error = true;
                response.message = exeption.InnerException.Message;
                response.status = 500;
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

                    Client clientsExists = clientService.GetClientById(clientId);

                    //Checks if credentials are valid
                    if (clientsExists != null)
                    {
                        WalletRepository walletRepository = new WalletRepository(context);
                        WalletService walletService = new WalletService(walletRepository);

                        TransactionRepository transactionRepository = new TransactionRepository(context);
                        TransactionService transactionService = new TransactionService(transactionRepository);

                        decimal currentBalance = walletService.GetBalance(clientsExists.ClientId);
                        int walletId = walletService.GetWalletByClientId(clientId).WalletId;
                        //Checks if the money in the wallet is enough for the payment
                        if (currentBalance > ammount)
                        {
                            Transaction payment = new Transaction();
                            payment.WalletId = walletId;
                            payment.Ammount = ammount;
                            payment.Type = "payment";
                            payment.Detail = detail;
                            transactionService.CreateTransaction(payment);

                            response.message = "Payment Succesull";
                            response.status = 200;
                            return response;
                        }
                        else
                        {
                            response.message = "Your current balance is not enough to make the payment";
                            response.error = true;
                            response.status = 403;
                            return response;
                        }

                    }
                    else
                    {
                        response.message = "Invalid Credentials";
                        response.status = 401;
                        response.error = true;
                        return response;
                    }                
                }
            }
            catch (Exception exeption)
            {
                response.error = true;
                response.message = exeption.InnerException.Message;
                response.status = 500;
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

                    Client clientsExists = clientService.GetClientByIdAndPhone(clientId, phone);

                    //Checks if credentials are valid 
                    if (clientsExists != null)
                    {
                        WalletRepository walletRepository = new WalletRepository(context);
                        WalletService walletService = new WalletService(walletRepository);

                        TransactionRepository transactionRepository = new TransactionRepository(context);
                        TransactionService transactionService = new TransactionService(transactionRepository);

                        Wallet wallet = walletService.GetWalletByClientId(clientId);

                        Transaction recharge = new Transaction();
                        recharge.WalletId = wallet.WalletId;
                        recharge.Ammount = ammount;
                        recharge.Type = "recharge";
                        recharge.Detail = detail;
                        transactionService.CreateTransaction(recharge);

                        response.message = "Recharge Completed Succesfully";
                        response.status = 200;

                        return response;
                    }
                    else
                    {
                        response.message = "Invalid Credentials";
                        response.error = true;
                        response.status = 401;
                        return response;
                    }   
                }
            }
            catch (Exception exeption)
            {
                response.error = true;
                response.message = exeption.InnerException.Message;
                response.status = 500;
                return response;
            }
        }

    }
}
