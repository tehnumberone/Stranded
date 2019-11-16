using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stranded.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CharacterModel { get; set; }
        public int Hp { get; set; }
        public int Level { get; set; }
        public int Hydration { get; set; }
        public int Hunger { get; set; }
    }
}
