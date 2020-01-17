using System.Collections.Generic;
using Library.Models;

namespace Stranded.Context.Interfaces
{
    public interface IBedContext
    {
        bool Create(Bed bed);
        bool Update(int id);
        bool Delete(int id);
        List<Bed> GetAllByCharID(int id);
    }
}
