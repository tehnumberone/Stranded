using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stranded.Context.Interfaces;
using Library.Models;

namespace Stranded.Repositories
{
    public class CharacterRepo
    {
        private readonly ICharacterContext ctx;

        public CharacterRepo(ICharacterContext context)
        {
            this.ctx = context;
        }
        public bool Create(Character c, Account acc)
        {
            return ctx.Create(c, acc);
        }

        public bool Update(Character character)
        {
            return ctx.Update(character);
        }

        public void Delete(int id)
        {
            ctx.Delete(id);
        }

        public Character GetById(int id)
        {
            return ctx.GetById(id);
        }

        public List<Character> GetAll(Account acc)
        {
            return ctx.GetAll(acc);
        }

        public List<string> GetAllCharModels()
        {
            return ctx.GetAllCharModels();
        }
    }
}
