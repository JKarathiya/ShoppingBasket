using ShoppingBasketTask.Models;
using ShoppingBasketTask.Repositories;
using ShoppingBasketTask.Repositories.Interfaces;
using ShoppingBasketTask.Services;
using ShoppingBasketTask.Services.Interfaces;
using System;
using System.Linq;

namespace ShoppingBasketTask.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Product Id from Product Repository
            const int Jumper_54_65_Id = 1;
            const int HeadLight_3_50_Id = 2;
            const int Gloves_10_50_Id = 3;
            const int Gloves_25_00_Id = 4;
            const int Jumper_26_00_Id = 5;
            const int GiftVoucher_30_00_Id = 6;

            //Gift voucher Id from Gift Voucher Repository
            const int ReedemGiftVoucher_5_00_Id = 1;
            const int ReedemGiftVoucher_30_00_Id = 2;

            //Offer voucher Id from Offer Voucher Repository
            const int ReedemOfferVoucher_5_off_HeadGear_Id = 1;
            const int ReedemOfferVoucher_5_off_Over50_Id = 2;


            /* Scenario 1:
             * 1 Jumper @ £54.65
             * 1 Head Light (Head Gear Category of Product) @ £3.50
             * Total: £58.15
             */
            Console.WriteLine("*** Scenario 1 ***");
            IShoppingBasket _shoppingBasket1 = new ShoppingBasket();
            IProductRepository _productRepository1 = new ProductRepository();
            IShoppingBasketProcessor _basketProcessor1 = new ShoppingBasketProcessor();
            BasketService _basketService1 = new BasketService(_basketProcessor1);
            _shoppingBasket1.AddtemToBasket(_productRepository1.GetProduct(Jumper_54_65_Id));
            _shoppingBasket1.AddtemToBasket(_productRepository1.GetProduct(HeadLight_3_50_Id));
            BasketServiceResponse _result1 = _basketService1.GetBasketTotalAmount(_shoppingBasket1);
            Console.WriteLine($"Total Amount at Checkout {_result1.BasketTotalAmount}");

            /* Scenario 2:
             * 1 Gloves @ £10.50
             * 1 Jumper @ £54.65
             * 1 x £5.00 Gift Voucher XXX-XXX applied
             * Total: £60.15
             */
            Console.WriteLine("*** Scenario 2 ***");
            IShoppingBasket _shoppingBasket2 = new ShoppingBasket();
            IProductRepository _productRepository2 = new ProductRepository();
            IGiftVoucherRepository _giftVoucherRepository2 = new GiftVoucherRepository();
            IOfferVoucherRepository _offerVoucherRepository2 = new OfferVoucherRepository();
            IShoppingBasketProcessor _basketProcessor2 = new ShoppingBasketProcessor();
            BasketService _basketService2 = new BasketService(_basketProcessor2);
            _shoppingBasket2.AddtemToBasket(_productRepository2.GetProduct(Gloves_10_50_Id));
            _shoppingBasket2.AddtemToBasket(_productRepository2.GetProduct(Jumper_54_65_Id));
            _shoppingBasket2.ApplyGiftVoucher(_giftVoucherRepository2.GetGiftVoucher(ReedemGiftVoucher_5_00_Id));
            BasketServiceResponse _result2 = _basketService2.GetBasketTotalAmount(_shoppingBasket2);
            Console.WriteLine($"Total Amount at Checkout {_result2.BasketTotalAmount}");

            /* Scenario 3:
             * 1 Gloves @ £25.00
             * 1 Jumper @ £26.00
             * 1 x £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY applied
             * Total: £51.00
             * Message: “There are no products in your basket applicable to Offer Voucher YYY-YYY.”
             */
            Console.WriteLine("*** Scenario 3 ***");
            IShoppingBasket _shoppingBasket3 = new ShoppingBasket();
            IProductRepository _productRepository3 = new ProductRepository();
            IOfferVoucherRepository _offerVoucherRepository3 = new OfferVoucherRepository();
            IShoppingBasketProcessor _basketProcessor3 = new ShoppingBasketProcessor();
            BasketService _basketService3 = new BasketService(_basketProcessor3);
            _shoppingBasket3.AddtemToBasket(_productRepository3.GetProduct(Gloves_25_00_Id));
            _shoppingBasket3.AddtemToBasket(_productRepository3.GetProduct(Jumper_26_00_Id));
            _shoppingBasket3.ApplyOfferVoucher(_offerVoucherRepository3.GetOfferVoucher(ReedemOfferVoucher_5_off_HeadGear_Id));
            BasketServiceResponse _result3 = _basketService3.GetBasketTotalAmount(_shoppingBasket3);
            Console.WriteLine($"Total Amount at Checkout {_result3.BasketTotalAmount}");
            Console.WriteLine($"Message at Checkout \"{_result3.Notifications.Aggregate((i, j) => i + j)}\"");

            /* Scenario 4:
             * 1 Gloves @ £25.00
             * 1 Jumper @ £26.00
             * 1 Head Light (Head Gear Category of Product) @ £3.50
             * 1 x £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY applied
             * Total: £51.00
             */
            Console.WriteLine("*** Scenario 4 ***");
            IShoppingBasket _shoppingBasket4 = new ShoppingBasket();
            IProductRepository _productRepository4 = new ProductRepository();
            IOfferVoucherRepository _offerVoucherRepository4 = new OfferVoucherRepository();
            IShoppingBasketProcessor _basketProcessor4 = new ShoppingBasketProcessor();
            BasketService _basketService4 = new BasketService(_basketProcessor4);
            _shoppingBasket4.AddtemToBasket(_productRepository4.GetProduct(Gloves_25_00_Id));
            _shoppingBasket4.AddtemToBasket(_productRepository4.GetProduct(Jumper_26_00_Id));
            _shoppingBasket4.AddtemToBasket(_productRepository4.GetProduct(HeadLight_3_50_Id));
            _shoppingBasket4.ApplyOfferVoucher(_offerVoucherRepository4.GetOfferVoucher(ReedemOfferVoucher_5_off_HeadGear_Id));
            BasketServiceResponse _result4 = _basketService4.GetBasketTotalAmount(_shoppingBasket4);
            Console.WriteLine($"Total Amount at Checkout {_result4.BasketTotalAmount}");

            /* Scenario 5:
             * 1 Gloves @ £25.00
             * 1 Jumper @ £26.00
             * Sub Total: £51.00
             * 1 x £5.00 Gift Voucher XXX-XXX applied
             * 1 x £5.00 off baskets over £50.00 Offer Voucher YYY-YYY applied
            */
            Console.WriteLine("*** Scenario 5 ***");
            IShoppingBasket _shoppingBasket5 = new ShoppingBasket();
            IProductRepository _productRepository5 = new ProductRepository();
            IGiftVoucherRepository _giftVoucherRepository5 = new GiftVoucherRepository();
            IOfferVoucherRepository _offerVoucherRepository5 = new OfferVoucherRepository();
            IShoppingBasketProcessor _basketProcessor5 = new ShoppingBasketProcessor();
            BasketService _basketService5 = new BasketService(_basketProcessor5);
            _shoppingBasket5.AddtemToBasket(_productRepository5.GetProduct(Gloves_25_00_Id));
            _shoppingBasket5.AddtemToBasket(_productRepository5.GetProduct(Jumper_26_00_Id));
            _shoppingBasket5.ApplyGiftVoucher(_giftVoucherRepository5.GetGiftVoucher(ReedemGiftVoucher_5_00_Id));
            _shoppingBasket5.ApplyOfferVoucher(_offerVoucherRepository5.GetOfferVoucher(ReedemOfferVoucher_5_off_Over50_Id));
            BasketServiceResponse _result5 = _basketService5.GetBasketTotalAmount(_shoppingBasket5);
            Console.WriteLine($"Total Amount at Checkout {_result5.BasketTotalAmount}");

            /* Scenario 6:
             * 1 Gloves @ £25.00
             * 1 £30 Gift Voucher @ £30.00
             * Sub Total: £55.00
             * 1 x £5.00 off baskets over £50.00 Offer Voucher YYY-YYY applied
             * Total: £55.00
             * Message: “You have not reached the spend threshold for Gift Voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total.”
             */
            Console.WriteLine("*** Scenario 6 ***");
            IShoppingBasket _shoppingBasket6 = new ShoppingBasket();
            IProductRepository _productRepository6 = new ProductRepository();
            IOfferVoucherRepository _offerVoucherRepository6 = new OfferVoucherRepository();
            IShoppingBasketProcessor _basketProcessor6 = new ShoppingBasketProcessor();
            BasketService _basketService6 = new BasketService(_basketProcessor6);
            _shoppingBasket6.AddtemToBasket(_productRepository6.GetProduct(Gloves_25_00_Id));
            _shoppingBasket6.AddtemToBasket(_productRepository6.GetProduct(GiftVoucher_30_00_Id));
            _shoppingBasket6.ApplyOfferVoucher(_offerVoucherRepository6.GetOfferVoucher(ReedemOfferVoucher_5_off_Over50_Id));
            BasketServiceResponse _result6 = _basketService6.GetBasketTotalAmount(_shoppingBasket6);
            Console.WriteLine($"Total Amount at Checkout {_result6.BasketTotalAmount}");
            Console.WriteLine($"Message at Checkout \"{_result6.Notifications.Aggregate((i, j) => i + j)}\"");

            /* Scenario 7:
             * 1 Gloves @ £25.00
             *  Sub Total: £25.00
             * 1 x £30.00 Gift Voucher XXX-XXX applied
             * Total: £0.00
             */
            Console.WriteLine("*** Scenario 7 ***");
            IShoppingBasket _shoppingBasket7 = new ShoppingBasket();
            IProductRepository _productRepository7 = new ProductRepository();
            IGiftVoucherRepository _giftVoucherRepository7 = new GiftVoucherRepository();
            IShoppingBasketProcessor _basketProcessor7 = new ShoppingBasketProcessor();
            BasketService _basketService7 = new BasketService(_basketProcessor7);
            _shoppingBasket7.AddtemToBasket(_productRepository7.GetProduct(Gloves_25_00_Id));
            _shoppingBasket7.ApplyGiftVoucher(_giftVoucherRepository7.GetGiftVoucher(ReedemGiftVoucher_30_00_Id));
            BasketServiceResponse _result7 = _basketService7.GetBasketTotalAmount(_shoppingBasket7);
            Console.WriteLine($"Total Amount at Checkout {_result7.BasketTotalAmount}");
        }

    }

}
