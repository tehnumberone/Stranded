using System;
using System.Collections.Generic;
using Library.Models;

namespace Stranded.Context.Interfaces
{
    public interface IInventoryContext
    {
        int Create(/*Character*/);
        bool Update(int id);
        bool Delete(int id);

    }
}
