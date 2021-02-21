using ShoppingBasketTask.Services.Interfaces;

namespace ShoppingBasketTask.Services
{
    public class ShoppingBasketProcessorFactory : IShoppingBasketProcessorFactory
    {
        public IShoppingBasketProcessor CreateGiftVoucherProcessor() => new GiftVoucherProcessor();
        public IShoppingBasketProcessor CreateOfferVoucherProcessor()=> new OfferVoucherProcessor();
        public IShoppingBasketProcessor CreateProductProcessor() => new ProductProcessor();
    }
}
