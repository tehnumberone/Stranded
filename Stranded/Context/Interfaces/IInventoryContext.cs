using Library.Models;

namespace Stranded.Context.Interfaces
{
    public interface IInventoryContext
    {
        bool Create(Inventory inventory);
        bool Update(int id);
        bool Delete(int id);
        Inventory GetInventory(int characterID);
    }
}
