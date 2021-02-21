namespace ShoppingBasketTask.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
