using System.Collections.Generic;
using Library.Models;

namespace Stranded.Context.Interfaces
{
    public interface IItemContext
    {
        bool Create(Item item);
        bool Update(int id);
        bool Delete(int id);
        List<Item> GetAllItems(int sorteertype);
        Item GetItem(int id);
    }
}
