using ShoppingBasketTask.Constants;

namespace ShoppingBasketTask.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category ProductCategory { get; set; }
    }
}
