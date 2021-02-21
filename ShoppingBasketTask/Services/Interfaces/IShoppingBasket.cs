using ShoppingBasketTask.Models;
using System.Collections.Generic;

namespace ShoppingBasketTask.Services.Interfaces
{
    public interface IShoppingBasket
    {
        void AddtemToBasket(Product product);
        IEnumerable<BasketItem> GetBasketItems();
        IList<string> Messages { get; set; }
        decimal Total { get; set; }
        List<GiftVoucher> GetGiftVoucher();
        OfferVoucher GetOfferVoucher();
        void ApplyGiftVoucher(GiftVoucher giftVoucher);
        void ApplyOfferVoucher(OfferVoucher offerVoucher);
    }
}
