using ShoppingBasketTask.Models;
using ShoppingBasketTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketTask.Services
{
    public class ShoppingBasket : IShoppingBasket
    {
        private readonly List<BasketItem> _basketItems = new List<BasketItem>();
        private OfferVoucher _offerVoucher;
        private List<GiftVoucher> _giftVoucher = new List<GiftVoucher>();
        private static string GetItemId() => Guid.NewGuid().ToString();

        public void AddtemToBasket(Product product)
        {
            var basketItem = _basketItems.FirstOrDefault(x => x.Product.Id == product.Id);

            if (basketItem != null)
                basketItem.Quantity++;
            else
                _basketItems.Add(new BasketItem
                {
                    ItemId = GetItemId(),
                    Product = product,
                    Quantity = 1
                });
        }

        public IEnumerable<BasketItem> GetBasketItems() => _basketItems;

        public IList<string> Messages { get; set; } = new List<string>();
        public decimal Total { get; set; }

        public void ApplyGiftVoucher(GiftVoucher giftVoucher) => _giftVoucher.Add(giftVoucher);

        public void ApplyOfferVoucher(OfferVoucher offerVoucher) => _offerVoucher = offerVoucher;

        public List<GiftVoucher> GetGiftVoucher() => _giftVoucher;

        public OfferVoucher GetOfferVoucher() => _offerVoucher;
    }
}
