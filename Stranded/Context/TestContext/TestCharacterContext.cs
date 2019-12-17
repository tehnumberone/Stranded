using Stranded.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stranded.Models.ViewModels;
using Stranded.Models;

namespace Stranded.Context.TestContext
{
    public class TestCharacterContext : ICharacterContext
    {
        public bool Create(Character c, Account acc)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Character> GetAll(Account acc)
        {
            throw new NotImplementedException();
        }

        public List<CharacterModel> GetAllCharModels()
        {
            List<CharacterModel> characterModels = new List<CharacterModel>();
            characterModels.Add(new CharacterModel() { Id = 1, characterModel = "char1.jpg" });
            characterModels.Add(new CharacterModel() { Id = 2, characterModel = "char2.jpg" });
            characterModels.Add(new CharacterModel() { Id = 3, characterModel = "char3.jpg" });
            return characterModels;
        }

        public Character GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
