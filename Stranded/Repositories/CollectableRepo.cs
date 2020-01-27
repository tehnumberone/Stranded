using System;
using Stranded.Context.Interfaces;
using Library.Models;

namespace Stranded.Repositories
{
    public class CollectableRepo
    {
        private readonly ICollectableContext ctx;

        public CollectableRepo(ICollectableContext context)
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
