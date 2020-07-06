using DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModelLayer.Interfaces
{
    public interface IClientRepository
    {
        void CreateClient(Client client);
        Client GetClient(string clientId);
        Client GetClient(string clientId, string phone);
   
    }
}
