using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DataAccesLayer.Config;
using DataAccesLayer.Repositories;
using DataModelLayer.Models;
using ServicesLayer;
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
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public ClientServiceResponse GetClients()
        {
            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    ClientRepository userRepository = new ClientRepository(context);
                    ClientService clientService = new ClientService(userRepository);
                    IEnumerable<Client> clients = clientService.GetAllClients();
                    ClientServiceResponse response = new ClientServiceResponse();

                    response.Clients = clients.ToArray();
                    return response;

                }
            }
            catch (Exception exeption)
            {
                ClientServiceResponse response = new ClientServiceResponse();
                response.IsError = true;
                response.Messagge = exeption.Message;
                return response;
            }
        }


        [WebMethod]
        public SignInResponse SignIn(SignInRequest req)
        {
            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    ClientRepository userRepository = new ClientRepository(context);
                    ClientService clientService = new ClientService(userRepository);
                    Client newClient = new Client();

                    newClient.ClientId = req.ClientId;
                    newClient.Name = req.Name;
                    newClient.Phone = req.Phone;
                    newClient.Email = req.Email;
                    newClient.Password = req.Password;

                    clientService.CreateClient(newClient);

                    SignInResponse response = new SignInResponse();
                   
                    response.Messagge = "Client Created Succesully";
                    response.StatusCode = 200;


                    return response;

                }
            }
            catch (Exception exeption)
            {
                SignInResponse response = new SignInResponse();
                response.IsError = true;
                response.Messagge = exeption.Message;
                return response;
            }
        }
    }
}
