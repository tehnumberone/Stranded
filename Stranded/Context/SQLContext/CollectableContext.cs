using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Library.Models;
using Stranded.Context.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Stranded.Context.SQLContext
{
    public class CollectableContext : ICollectableContext
    {

        private readonly string _connectionString;

        public CollectableContext(IConfiguration configuration)
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

        public bool Create(Collectable collectable)
        {
            throw new NotImplementedException();
        }

        public List<Collectable> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
