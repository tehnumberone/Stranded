using System;
using System.Collections.Generic;
using Stranded.Models;
using Stranded.Models.ViewModels;

namespace Stranded.Context.Interfaces
{
    public interface IItemContext
    {
        bool Create(Item item);
        bool Update(int id);
        bool Delete(int id);
        List<Item> GetAllItems();

    }
}
