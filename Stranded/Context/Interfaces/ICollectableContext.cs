using System;
using System.Collections.Generic;
using Stranded.Models;

namespace Stranded.Context.Interfaces
{
    public interface ICollectableContext
    {
        int Create(/*Character*/);
        bool Update(int id);
        bool Delete(int id);

    }
}
