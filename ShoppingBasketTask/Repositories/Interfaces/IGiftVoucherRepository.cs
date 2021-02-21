using ShoppingBasketTask.Models;

namespace ShoppingBasketTask.Repositories.Interfaces
{
    public interface IGiftVoucherRepository
    {
        GiftVoucher GetGiftVoucher(int id);
    }
}