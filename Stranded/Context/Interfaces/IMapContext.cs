using Library.Models;

namespace Stranded.Context.Interfaces
{
    public interface IMapContext
    {
        bool Create(Map map);
        bool Update(int id);
        bool Delete(int id);
        Map GetByCharID(int characterID);
    }
}
