using ShoppingBasketTask.Constants;
using ShoppingBasketTask.Models;
using ShoppingBasketTask.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketTask.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IEnumerable<Product> _products;

        public ProductRepository()
        {
            LoadProducts();
        }

        public Product GetProduct(int id) => _products.FirstOrDefault(p => p.Id == id);

        private void LoadProducts()
        {
            _products = new List<Product>
            {
                new Product {
                    Id    = 1,
                    Name  = "Jumper",
                    Price = 54.65m,
                    ProductCategory = Category.Clothes
                },
                new Product {
                    Id    = 2,
                    Name  = "Head Light",
                    Price = 3.50m,
                    ProductCategory = Category.HeadGear
                },
                new Product {
                    Id    = 3,
                    Name  = "Gloves",
                    Price = 10.50m,
                    ProductCategory = Category.Gloves
                },
                new Product {
                    Id    = 4,
                    Name  = "Gloves",
                    Price = 25.00m,
                    ProductCategory = Category.Gloves
                },
                new Product {
                    Id    = 5,
                    Name  = "Jumper",
                    Price = 26.00m,
                    ProductCategory = Category.Clothes
                },
                 new Product {
                    Id    = 6,
                    Name  = "Gift Voucher",
                    Price = 30.00m,
                    ProductCategory = Category.GiftVoucher
                },
            };

        }
    }
}
