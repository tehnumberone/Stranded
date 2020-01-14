using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Stranded.ViewModels;

namespace Stranded.Converters
{
    public class CharacterToCharacterVM
    {
        public CharacterViewModel ToCharVM(Character c)
        {
            var cvm = new CharacterViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                CharacterModel = c.CharacterModel,
                Hp = c.Hp,
                Hunger = c.Hunger,
                Hydration = c.Hydration
            };
            return cvm;
        }

        public Character ToCharacter(CharacterViewModel cvm)
        {
            var c = new Character()
            {
                Name = cvm.Name,
                CharacterModel = cvm.CharacterModel,
                Hp = cvm.Hp,
                Hunger = cvm.Hunger,
                Hydration = cvm.Hydration
            };
            return c;
        }
    }
}
