using ShoppingBasketTask.Models;
using ShoppingBasketTask.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketTask.Repositories
{
    public class GiftVoucherRepository : IGiftVoucherRepository
    {
        private IEnumerable<GiftVoucher> _giftVoucherRepositories;

        public GiftVoucherRepository()
        {
            LoadGiftVouchers();
        }

        public GiftVoucher GetGiftVoucher(int id)
        {
            return _giftVoucherRepositories.FirstOrDefault(x => x.Id == id);
        }

        private void LoadGiftVouchers()
        {
            _giftVoucherRepositories = new List<GiftVoucher>
            {
                new GiftVoucher
                {
                    Id=1,
                    Code="XXX-XXX",
                    AmountOfDiscount = 5m
                },
                new GiftVoucher
                {
                    Id=2,
                    Code="XXX-XXX",
                    AmountOfDiscount = 30m
                }
            };
        }
    }
}
