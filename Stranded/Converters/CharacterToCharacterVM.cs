using Library.Models;
using Stranded.ViewModels;

namespace Stranded.Converters
{
    public class CharacterToCharacterVM
    {
        static public CharacterViewModel ToCharVM(Character c)
        {
            var cvm = new CharacterViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                CharacterModel = c.CharacterModel,
                Hp = c.Hp,
                Hunger = c.Hunger,
                Hydration = c.Hydration,
                Level = c.Level
            };
            return cvm;
        }

        static public Character ToCharacter(CharacterViewModel cvm)
        {
            var c = new Character()
            {
                Name = cvm.Name,
                CharacterModel = cvm.CharacterModel,
                Hp = cvm.Hp,
                Hunger = cvm.Hunger,
                Hydration = cvm.Hydration,
                Level = cvm.Level
            };
            return c;
        }
    }
}
