using System.Collections.Generic;

namespace ShoppingBasketTask.Models
{
    public class BasketResponse
    {
        public bool Success { get; set; }
        public decimal BasketTotalAmount { get; set; }
        public List<string> Notifications { get; set; }
    }
}
