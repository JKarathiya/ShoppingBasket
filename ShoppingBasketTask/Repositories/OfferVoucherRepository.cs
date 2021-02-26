using ShoppingBasketTask.Constants;
using ShoppingBasketTask.Models;
using ShoppingBasketTask.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketTask.Repositories
{
    public class OfferVoucherRepository : IOfferVoucherRepository
    {
        private IEnumerable<OfferVoucher> _offerVouchers;

        public OfferVoucherRepository()
        {
            LoadofferVouchers();
        }

        public OfferVoucher GetOfferVoucher(int id) => _offerVouchers.FirstOrDefault(x => x.Id == id);

        private void LoadofferVouchers()
        {
            _offerVouchers = new List<OfferVoucher>
            {
                new OfferVoucher
                {
                    Id = 1,
                    Code = "YYY-YYY",
                    DiscountOffAmount = 5m,
                    Threshold = 50m,
                    IsSpecificToProduct = true,
                    ProductCategory = Category.HeadGear
                },
                new OfferVoucher
                {
                    Id = 2,
                    Code = "YYY-YYY",
                    DiscountOffAmount = 5m,
                    Threshold = 50m,
                    IsSpecificToProduct = false
                }
            };
        }
    }
}
