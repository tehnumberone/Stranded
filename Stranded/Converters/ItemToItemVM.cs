using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Stranded.ViewModels;

namespace Stranded.Converters
{
    public class ItemToItemVM
    {
        public Item ToItem(ItemViewModel ivm)
        {
            MemoryStream memoryStream = new MemoryStream();
            var item = new Item()
            {
                Id = ivm.Id,
                Name = ivm.Name,
                ItemType = (Library.Models.ItemType)ivm.ItemType,
                ImageFile = memoryStream.ToArray()
            };
            return item;
        }
        public ItemViewModel ToItemVM(Item item)
        {
            var ivm = new ItemViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                ItemType = (Stranded.ViewModels.ItemType)item.ItemType,
                ImageFile = Convert.ToBase64String(item.ImageFile)
            };
            return ivm;
        }
    }
}
