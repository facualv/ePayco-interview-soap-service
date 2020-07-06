using System;
using System.Collections.Generic;
using DataAccesLayer.Repositories;
using DataModelLayer.Models;


namespace ServicesLayer
{
    public class ClientService
    {
        #region Fields

        private readonly ClientRepository _clientRepository;

        #endregion

        #region Props

        #endregion

        #region Constructors

        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        #endregion

        #region Method

        public Client GetClient(Client targetClient)
        {
            return _clientRepository.GetClient(targetClient);
        }

        public IEnumerable<Client> GetAllClients()
        {
            IEnumerable<Client> listaClientes = _clientRepository.GetAllClients(); 
            return listaClientes;
        }

        public void CreateClient(Client client)
        {
             _clientRepository.CreateClient(client);
        }

 

        #endregion

    }
}
