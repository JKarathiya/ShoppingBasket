using ShoppingBasketTask.Models;

namespace ShoppingBasketTask.Repositories.Interfaces
{
    public interface IOfferVoucherRepository
    {
        OfferVoucher GetOfferVoucher(int id);
    }
}