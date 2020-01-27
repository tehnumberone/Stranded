using System;
namespace Library.Models
{
    public class Building
    {
        public string Name { get; set; }
        public enum BuildingType
        {
        }
        public int Size { get; set; }
        public int LootChance { get; set; }
        public String Location { get; set; }
    }
}
