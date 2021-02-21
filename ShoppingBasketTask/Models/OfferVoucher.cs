using ShoppingBasketTask.Constants;

namespace ShoppingBasketTask.Models
{
    public class OfferVoucher
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountOffAmount { get; set; }
        public decimal Threshold { get; set; }
        public Category ProductCategory { get; set; }
        public bool IsSpecificToProduct { get; set; } = false;
    }
}
