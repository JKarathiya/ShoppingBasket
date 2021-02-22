namespace ShoppingBasketTask.Services.Interfaces
{
    public interface IShoppingBasketProcessor
    {
        IShoppingBasketProcess CreateGiftVoucherProcessor();
        IShoppingBasketProcess CreateOfferVoucherProcessor();
        IShoppingBasketProcess CreateProductProcessor();
    }
}
