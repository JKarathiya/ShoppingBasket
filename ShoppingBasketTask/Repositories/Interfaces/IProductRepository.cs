using ShoppingBasketTask.Models;

namespace ShoppingBasketTask.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
    }
}