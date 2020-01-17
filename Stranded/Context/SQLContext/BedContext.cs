using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Library.Models;
using Stranded.Context.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Stranded.Context.SQLContext
{
    public class BedContext : IBedContext
    {

        private readonly string _connectionString;

        public BedContext(IConfiguration configuration)
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

        public bool Create(Bed bed)
        {
            throw new NotImplementedException();
        }

        public List<Bed> GetAllByCharID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
