using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stranded.Models
{
    public class Character
    {
        public int Id { get; }
        public string Name { get; set; }
        public string CharacterModel { get; set; }
        public int Hp { get; set; }
        public int Level { get; set; }
        public int Hydration { get; set; }
        public int Hunger { get; set; }
        public Character(int Id, string Name, string CharacterModel)
        {
            this.Id = Id;
            this.Name = Name;
            this.CharacterModel = CharacterModel;
            this.Hp = 10;
            this.Hunger = 10;
            this.Hydration = 10;
            this.Level = 1;
        }
        public Character()
        {

        }
    }
}
