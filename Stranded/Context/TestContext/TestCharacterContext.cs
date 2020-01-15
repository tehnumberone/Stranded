using Stranded.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stranded.ViewModels;
using Library.Models;

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

        public List<string> GetAllCharModels()
        {
            List<string> characterModels = new List<string>();
            characterModels.Add("char1.jpg");
            characterModels.Add("char2.jpg");
            characterModels.Add("char3.jpg");
            return characterModels;
        }

        public Character GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
