using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stranded.Models.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType ItemType { get; set; }
        public List<Item> DBItems { get; set; }
        public List<ItemViewModel> AlleItems { get; set; }
        public int Amount { get; set; }
        public string ImageFile { get; set; }
    }
}
