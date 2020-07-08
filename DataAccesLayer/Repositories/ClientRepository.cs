using DataAccesLayer.Config;
using DataModelLayer.Interfaces;
using DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccesLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataBaseContext _context;

        public ClientRepository(DataBaseContext contex)
        {
            _context = contex;
        }

        public Client GetClient(string clientId)
        {
            return _context.Set<Client>().Find(clientId);
        }

        public Client GetClient(string clientId, string phone)
        {
            return _context.Set<Client>().SingleOrDefault(x => x.ClientId == clientId && x.Phone == phone);
        }

        public Client GetClientByEmail(string email)
        {   
            Client client = _context.Set<Client>().SingleOrDefault(x => x.Email == email);
            return client;
        }

        public void CreateClient(Client client)
        {
            _context.Set<Client>().Add(client);
            _context.SaveChanges();
        }

    }
}
