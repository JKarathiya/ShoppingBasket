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

            if (!giftVouchers.Any())
                return shoppingBasket;

            var totalAmountOfgiftVouchers = giftVouchers.Sum(x => x.AmountOfDiscount);

            foreach (var basketItem in shoppingBasket.GetBasketItems())
            {
                if (basketItem.Product.ProductCategory != Category.GiftVoucher && totalAmountOfgiftVouchers > 0)
                {
                    var productPrice = basketItem.Product.Price * basketItem.Quantity;
                    if (productPrice > totalAmountOfgiftVouchers)
                    {
                        shoppingBasket.Total = shoppingBasket.Total - totalAmountOfgiftVouchers;
                        totalAmountOfgiftVouchers = 0;
                    }
                    else
                    {
                        totalAmountOfgiftVouchers = totalAmountOfgiftVouchers - productPrice;
                        shoppingBasket.Total -= productPrice;
                    }
                }
            }
            return shoppingBasket;
        }
    }
}
