using System;
using System.IO;
using Library.Models;
using Stranded.ViewModels;

namespace Stranded.Converters
{
    public class ItemToItemVM
    {
        static public Item ToItem(ItemViewModel ivm)
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
        static public Item ToItem(ItemCreationViewModel icvm)
        {
            MemoryStream memoryStream = new MemoryStream();
            icvm.ImageFile.CopyTo(memoryStream);
            var item = new Item()
            {
                Id = icvm.Id,
                Name = icvm.Name,
                ItemType = (Library.Models.ItemType)icvm.ItemType,
                ImageFile = memoryStream.ToArray()
            };
            return item;
        }
        static public ItemViewModel ToItemVM(Item item)
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
