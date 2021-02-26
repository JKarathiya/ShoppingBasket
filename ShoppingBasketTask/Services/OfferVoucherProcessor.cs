using ShoppingBasketTask.Constants;
using ShoppingBasketTask.Services.Interfaces;
using System;
using System.Linq;

namespace ShoppingBasketTask.Services
{
    public class OfferVoucherProcessor : IShoppingBasketProcess
    {
        public IShoppingBasket Process(IShoppingBasket shoppingBasket)
        {
            var offerVoucher = shoppingBasket.GetOfferVoucher();

            if (offerVoucher == null) return shoppingBasket;

            if (!ValidateOfferVoucherForThreshold(shoppingBasket)) return shoppingBasket;

            if (!offerVoucher.IsSpecificToProduct)
            {
                shoppingBasket.Total = shoppingBasket.Total - offerVoucher.DiscountOffAmount;
                return shoppingBasket;
            }

            var ItemsInDiscountCategory = shoppingBasket.GetBasketItems().Where(x => x.Product.ProductCategory == offerVoucher.ProductCategory);
            
            if (ItemsInDiscountCategory.Any())  
                shoppingBasket.Total -= ItemsInDiscountCategory.Sum(x => x.Product.Price);
            else 
                shoppingBasket.Messages.Add("There are no products in your basket applicable to Offer Voucher YYY-YYY.");

            return shoppingBasket;
        }

        private bool ValidateOfferVoucherForThreshold(IShoppingBasket shoppingBasket)
        {
            var totalGiftAmount = shoppingBasket.GetBasketItems().Where(x => x.Product.ProductCategory
                                                                             == Category.GiftVoucher).Sum(x => x.Product.Price * x.Quantity);
            var basketsTotal = shoppingBasket.Total - totalGiftAmount;
            var discountVoucher = shoppingBasket.GetOfferVoucher();

            if (basketsTotal >= discountVoucher.Threshold)
                return true;

            var additonalAmountToSpend = discountVoucher.Threshold - basketsTotal + 0.01m;
            shoppingBasket.Messages.Add($"You have not reached the spend threshold for Gift Voucher {discountVoucher.Code}. Spend another £{additonalAmountToSpend:F2} to receive £{discountVoucher.DiscountOffAmount:F2} discount from your basket total.");
            return false;
        }
    }
}
