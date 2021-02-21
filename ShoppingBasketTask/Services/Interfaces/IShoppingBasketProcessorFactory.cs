namespace ShoppingBasketTask.Services.Interfaces
{
    public interface IShoppingBasketProcessorFactory
    {
        IShoppingBasketProcessor CreateGiftVoucherProcessor();
        IShoppingBasketProcessor CreateOfferVoucherProcessor();
        IShoppingBasketProcessor CreateProductProcessor();
    }
}
