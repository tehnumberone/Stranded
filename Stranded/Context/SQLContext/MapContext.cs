﻿using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Library.Models;
using Stranded.Context.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Stranded.Context.SQLContext
{
    public class MapContext : IMapContext
    {
        private readonly string _connectionString;

        public MapContext(IConfiguration configuration)
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

        public bool Create(Map map)
        {
            throw new NotImplementedException();
        }

        public Map GetByCharID(int characterID)
        {
            throw new NotImplementedException();
        }
    }
}
