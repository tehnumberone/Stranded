using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Library.Models;
using Stranded.Context.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Stranded.Context.SQLContext
{
    public class InventoryContext : IInventoryContext
    {
        private readonly string _connectionString;

        public InventoryContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Create(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public Inventory GetInventory(int characterID)
        {
            throw new NotImplementedException();
        }
    }
}
