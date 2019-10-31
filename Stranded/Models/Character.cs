using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stranded.Models
{
    public class Character
    {
        public int Id { get;}
        public string Name { get; set; }
        public int CharacterModel { get; set; }
        public Character()
        {
        }
    }
}
