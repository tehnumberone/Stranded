using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stranded.Context.Interfaces;
using Stranded.Models;
using Stranded.Models.ViewModels;

namespace Stranded.Repositories
{
    public class ItemRepo
    {
        private readonly IItemContext ctx;

        public ItemRepo(IItemContext context)
        {
            this.ctx = context;
        }

        public bool Create(Item item)
        {
            return ctx.Create(item);
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            return ctx.Delete(id);
        }
        public List<Item> GetAllItems(int sorteertype)
        {
            return ctx.GetAllItems(sorteertype);
        }
    }
}
