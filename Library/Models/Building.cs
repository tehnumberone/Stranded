using System;
using System.Collections.Generic;
using System.Text;

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
