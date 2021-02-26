using ShoppingBasketTask.Constants;
using ShoppingBasketTask.Services.Interfaces;
using System.Linq;

namespace ShoppingBasketTask.Services
{
    public class GiftVoucherProcessor : IShoppingBasketProcess
    {
        public IShoppingBasket Process(IShoppingBasket shoppingBasket)
        {
            var giftVouchers = shoppingBasket.GetGiftVoucher();

            if (!giftVouchers.Any())  return shoppingBasket;

            var totalAmountOfgiftVouchers = giftVouchers.Sum(x => x.AmountOfDiscount);

            var totalAmount = shoppingBasket.GetBasketItems().Where(x => x.Product.ProductCategory != Category.GiftVoucher).Sum(x => x.Product.Price * x.Quantity);
            var totalGiftAmount = shoppingBasket.Total - totalAmount;

            var remainingAmount = totalAmount >= totalAmountOfgiftVouchers ? totalAmount - totalAmountOfgiftVouchers : 0;
            shoppingBasket.Total = totalGiftAmount + remainingAmount;

            return shoppingBasket;
        }
    }
}
