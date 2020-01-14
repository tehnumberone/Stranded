using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stranded.ViewModels
{
    public class CharacterCreationViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please insert a name first.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please select a character model first.")]
        public string CharacterModel { get; set; }
        public List<string> CharModels = new List<string>();
    }
}
