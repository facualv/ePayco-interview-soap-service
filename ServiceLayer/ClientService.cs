using System;
using System.Collections.Generic;
using DataAccesLayer.Repositories;
using DataModelLayer.Models;
using Org.BouncyCastle.Crypto.Modes.Gcm;

namespace ServiceLayer
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;
        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        #region Methods
        public Client GetClientById(string clientId)
        {
            return _clientRepository.GetClient(clientId);
        }
        public Client GetClientByIdAndPhone(string clientId, string phone)
        {
            return _clientRepository.GetClient(clientId, phone);
        }
        public Client GetClientByEmail(string email)
        {
            Client validClient = _clientRepository.GetClientByEmail(email);
            return validClient;
        }
        public void CreateClient(Client client)
        {
             _clientRepository.CreateClient(client);
        }
        #endregion

    }
}
