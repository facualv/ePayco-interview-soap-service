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

        public void CreateClient(Client client)
        {
            _context.Set<Client>().Add(client);
            _context.SaveChanges();
        }

        public Client GetClient(Client targetClient)
        {
            return _context.Set<Client>().FirstOrDefault(x => x.ClientId == targetClient.ClientId && x.Phone == targetClient.Phone);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Set<Client>().ToList();
        }

        public Client GetClient(string clientId, string phone)
        {
            return _context.Set<Client>().SingleOrDefault(x => x.ClientId == clientId && x.Phone == phone);
        }

    }
}
