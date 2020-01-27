namespace Library.Models
{

    public class Collectable
    {
        public int Size { get; set; }
        public int YieldAmount { get; set; }
        public enum CollectableType
        {
        }
        public enum RequiredTool
        {
        }
        public Item ConvertToItem()
        {
            var item = new Item();
            return item;
        }
    }
}
