using ShoppingBasketTask.Services.Interfaces;

namespace ShoppingBasketTask.Services
{
    public class ShoppingBasketProcessor : IShoppingBasketProcessor
    {
        public IShoppingBasketProcess CreateGiftVoucherProcessor() => new GiftVoucherProcessor();
        public IShoppingBasketProcess CreateOfferVoucherProcessor()=> new OfferVoucherProcessor();
        public IShoppingBasketProcess CreateProductProcessor() => new ProductProcessor();
    }
}
