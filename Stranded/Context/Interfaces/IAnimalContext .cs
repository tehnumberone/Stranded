using System.Collections.Generic;
using Library.Models;

namespace Stranded.Context.Interfaces
{
    public interface IAnimalContext
    {
        bool Create(Animal animal);
        bool Update(int id);
        bool Delete(int id);
        List<Animal> GetAll();
    }
}
