using ShoppingBasketTask.Services.Interfaces;
using System.Linq;

namespace ShoppingBasketTask.Services
{
    public class ProductProcessor : IShoppingBasketProcessor
    {
        public IShoppingBasket Process(IShoppingBasket shoppingBasket)
        {
            shoppingBasket.Total =
                shoppingBasket.GetBasketItems().Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);

            return shoppingBasket;
        }
    }
}