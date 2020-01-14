using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stranded.ViewModels
{
    public enum ItemType //If more item types are added, they have to be added to the item.cs model in the library too.
    {
        Tool = 1,
        Food,
        Medical,
        Weapon,
        Armour
    }
    public class ItemCreationViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please insert an item name first.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please pick an item type first.")]
        public ItemType ItemType { get; set; }
        public List<ItemType> ItemTypeList { get; set; }
        public int Amount { get; set; }
        [Required(ErrorMessage ="Please select an image for this item.")]
        public IFormFile ImageFile { get; set; }

    }
}
