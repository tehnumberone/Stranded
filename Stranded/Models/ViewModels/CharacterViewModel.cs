using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stranded.Models.ViewModels
{
    public class CharacterViewModel
    {
        public List<Character> Characters = new List<Character>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string CharacterModel { get; set; }
    }
}
