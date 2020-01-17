using System;
using System.Collections.Generic;
using Library.Models;

namespace Stranded.Context.Interfaces
{
    public interface ICollectableContext
    {
        bool Create(Collectable collectable);
        bool Update(int id);
        bool Delete(int id);
        List<Collectable> GetAll();
    }
}
