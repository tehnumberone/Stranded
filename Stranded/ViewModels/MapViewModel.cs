using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stranded.ViewModels
{
    public class MapViewModel
    {
        public int Size { get; set; }
        public CharacterViewModel character { get; set; }
        public List<ItemViewModel> allitems { get; set; }
    }
}
