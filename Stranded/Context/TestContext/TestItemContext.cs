using Stranded.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using System.IO;

namespace Stranded.Context.TestContext
{
    public class TestItemContext : IItemContext
    {
        public List<Item> ItemList = new List<Item>();
        public TestItemContext()
        {
            MemoryStream memoryStream = new MemoryStream();
            for (int i = 0; i < 10; i++)
            {
                Item testAccount = new Item
                {
                    Id = 1,
                    Name = "Item",
                    ItemType = ItemType.Medical,
                    ImageFile = memoryStream.ToArray()
                };
                ItemList.Add(testAccount);
            }
        }
        public bool Create(Item item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAllItems(int sorteertype)
        {
            return this.ItemList;
        }

        public Item GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
