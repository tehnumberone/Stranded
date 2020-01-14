using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stranded.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType ItemType { get; set; }
        public List<ItemViewModel> AllItems { get; set; }
        public int Sortingtype { get; set; }
        public int Amount { get; set; }
        public string ImageFile { get; set; }
    }
}
