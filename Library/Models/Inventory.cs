using System.Collections.Generic;
namespace Library.Models
{
    public class Inventory
    {
        public List<Item> AllItems { get; set; }
        public int Money { get; set; }

        public Inventory(List<Item> AllItems, int Money)
        {
            this.AllItems = AllItems;
            this.Money = Money;
        }
    }
}
