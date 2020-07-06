using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Config;
using DataAccesLayer.Repositories;
using DataModelLayer.Models;

namespace UnitTest.ClientTest
{
    [TestClass]
    public class ClientRepositoryTest
    {
        [TestMethod]
        public void GetClient()
        {
            Client targetClient = new Client();
            targetClient.ClientId = "33029950";
            targetClient.Phone = "15336335";


            using (DataBaseContext context = new DataBaseContext())
            {
                ClientRepository clientRepository = new ClientRepository(context);
                Client client = clientRepository.GetClient(targetClient);
     
                Assert.IsTrue(client != null && client.Name.Contains("facundo"));
            }
        }

        [TestMethod]
        public void CreateClient()
        {

            using (DataBaseContext context = new DataBaseContext())
            {
                ClientRepository clientRepository = new ClientRepository(context);
                Client client = new Client();
                client.Name = "Martin";
                client.ClientId = "31642858";
                client.Phone = "15662385";
                client.Email = "martin123@gmail.com";
                client.Password = "martincho";

                clientRepository.CreateClient(client);

                Assert.IsTrue(client.Name.Contains("Martin"));
            }
        }

        [TestMethod]
        public void GetAllClients()
        {

            using (DataBaseContext context = new DataBaseContext())
            {
                ClientRepository clientRepository = new ClientRepository(context);

                IEnumerable<Client> listaClientes = clientRepository.GetAllClients();

                

                Assert.IsTrue(listaClientes != null && listaClientes.Any());
            }
        }
    }
}
