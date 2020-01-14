using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public enum ItemType
    {
        Tool = 1,
        Food,
        Medical,
        Weapon,
        Armour
    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType ItemType { get; set; }
        public int Amount { get; set; }
        public byte[] ImageFile { get; set; }
        public Item(int Id, string Name, ItemType ItemType, byte[] ImageFile)
        {
            this.Id = Id;
            this.Name = Name;
            this.ItemType = ItemType;
            this.ImageFile = ImageFile;
        }
        public Item()
        {

        }
    }
}