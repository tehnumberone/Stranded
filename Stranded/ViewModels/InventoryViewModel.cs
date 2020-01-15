using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stranded.ViewModels
{
    public class InventoryViewModel
    {
        public List<ItemViewModel> AllItems { get; set; }
        public int Money { get; set; }
    }
}
