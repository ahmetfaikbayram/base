namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
    }
}