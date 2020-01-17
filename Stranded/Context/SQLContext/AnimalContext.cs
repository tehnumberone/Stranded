using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Library.Models;
using Stranded.Context.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Stranded.Context.SQLContext
{
    public class AnimalContext : IAnimalContext
    {

        private readonly string _connectionString;

        public AnimalContext(IConfiguration configuration)
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

        public bool Create(Animal animal)
        {
            throw new NotImplementedException();
        }

        public List<Animal> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
