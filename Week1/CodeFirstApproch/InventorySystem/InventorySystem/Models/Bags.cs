namespace InventorySystem.Models
{
    public class Bags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BagType { get; set; }
        public virtual Products ProductsId { get; set; }
    }
}
