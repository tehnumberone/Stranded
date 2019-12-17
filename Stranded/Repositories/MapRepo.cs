using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stranded.Context.Interfaces;

namespace Stranded.Repositories
{
    public class MapRepo
    {
        private readonly IMapContext ctx;

        public MapRepo(IMapContext context)
        {
            this.ctx = context;
        }

        public int Create()
        {
            throw new NotImplementedException();
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
