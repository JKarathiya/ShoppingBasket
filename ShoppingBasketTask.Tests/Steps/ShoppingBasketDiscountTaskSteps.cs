using FluentAssertions;
using ShoppingBasketTask.Models;
using ShoppingBasketTask.Repositories;
using ShoppingBasketTask.Repositories.Interfaces;
using ShoppingBasketTask.Services;
using ShoppingBasketTask.Services.Interfaces;
using System.Linq;
using TechTalk.SpecFlow;

namespace ShoppingBasketTask.Specs.Steps
{
    [Binding]
    public class ShoppingBasketDiscountTaskSteps
    {
        private readonly IShoppingBasket _shoppingBasket;
        private readonly IProductRepository _productRepository;
        private readonly IGiftVoucherRepository _giftVoucherRepository;
        private readonly IOfferVoucherRepository _offerVoucherRepository;
        private readonly IShoppingBasketProcessorFactory _basketProcessorFactory;
        private readonly BasketService _basketService;
        private BasketServiceResponse _result;

        //Product Id from Product Repository
        private const int Jumper_54_65_Id      = 1;
        private const int HeadLight_3_50_Id    = 2;
        private const int Gloves_10_50_Id      = 3;
        private const int Gloves_25_00_Id      = 4;
        private const int Jumper_26_00_Id      = 5;
        private const int GiftVoucher_30_00_Id = 6;

        //Gift Id from Gift Voucher Repository
        private const int ReedemGiftVoucher_5_00_Id = 1;
        private const int ReedemGiftVoucher_30_00_Id = 2;

        //Offer Id from Offer Voucher Repository
        const int ReedemOfferVoucher_5_off_HeadGear_Id = 1;
        const int ReedemOfferVoucher_5_off_Over50_Id   = 2;

        public ShoppingBasketDiscountTaskSteps()
        {
            _shoppingBasket = new ShoppingBasket();
            _productRepository = new ProductRepository();
            _giftVoucherRepository = new GiftVoucherRepository();
            _offerVoucherRepository = new OfferVoucherRepository();
            _basketProcessorFactory = new ShoppingBasketProcessorFactory();
            _basketService = new BasketService(_basketProcessorFactory);
        }

        /// <summary>
        /// 1 Jumper @ £54.65
        /// </summary>
        [Given(@"Add 1 Jumper @ £54.65 to basket")]
        public void GivenAddJumperAt54_65ToBasket()
        {
            _shoppingBasket.AddtemToBasket(_productRepository.GetProduct(Jumper_54_65_Id));
        }

        /// <summary>
        /// 1 Head Light \(Head Gear Category of Product\) @ £3.50 
        /// </summary>
        [Given(@"Add 1 Head Light \(Head Gear Category of Product\) @ £3.50 to basket")]
        public void GivenAddHeadLightHeadGearCategoryOfProductAt3_50ToBasket()
        {
            _shoppingBasket.AddtemToBasket(_productRepository.GetProduct(HeadLight_3_50_Id));
        }
        /// <summary>
        /// Add 1 Gloves @ £10.50 to basket
        /// </summary>
        [Given(@"Add 1 Gloves @ £10.50 to basket")]
        public void GivenAddGlovesAt10_50ToBasket()
        {
            _shoppingBasket.AddtemToBasket(_productRepository.GetProduct(Gloves_10_50_Id));
        }
        /// <summary>
        /// 
        /// </summary>
        [Given(@"Apply 1 x £5.00 Gift Voucher XXX-XXX")]
        public void GivenApplyXGiftVoucherOf5_00_XXX_XXX()
        {
            _shoppingBasket.ApplyGiftVoucher(_giftVoucherRepository.GetGiftVoucher(ReedemGiftVoucher_5_00_Id));
        }
        /// <summary>
        /// 
        /// </summary>
        [Given(@"Add 1 Gloves @ £25.00 to basket")]
        public void GivenAddGlovesAt25_00ToBasket()
        {
            _shoppingBasket.AddtemToBasket(_productRepository.GetProduct(Gloves_25_00_Id));
        }
        /// <summary>
        /// 
        /// </summary>
        [Given(@"Add 1 Jumper @ £26.00 to basket")]
        public void GivenAddJumperToBasket()
        {
            _shoppingBasket.AddtemToBasket(_productRepository.GetProduct(Jumper_26_00_Id));
        }
        /// <summary>
        /// 
        /// </summary>
        [Given(@"1 x £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY applied")]
        public void GivenXOffHeadGearInBasketsOverOfferVoucherYYY_YYYApplied()
        {
            _shoppingBasket.ApplyOfferVoucher(_offerVoucherRepository.GetOfferVoucher(ReedemOfferVoucher_5_off_HeadGear_Id));
        }
        /// <summary>
        /// 
        /// </summary>
        [Given(@"Apply 1 x £30.00 Gift Voucher XXX-XXX")]
        public void GivenApplyXGiftVoucherOf30_00_XXX_XXX()
        {
            _shoppingBasket.ApplyGiftVoucher(_giftVoucherRepository.GetGiftVoucher(ReedemGiftVoucher_30_00_Id));
        }
        /// <summary>
        /// 
        /// </summary>
        [Given(@"Add 1 £30 Gift Voucher @ £30.00 to basket")]
        public void GivenAddGiftVoucherToBasket()
        {
            _shoppingBasket.AddtemToBasket(_productRepository.GetProduct(GiftVoucher_30_00_Id));
        }
        /// <summary>
        /// 
        /// </summary>
        [Given(@"Apply 1 x £5.00 off baskets over £50.00 Offer Voucher YYY-YYY applied")]
        public void GivenApplyXOffBasketsOverOfferVoucherYYY_YYYApplied()
        {
            _shoppingBasket.ApplyOfferVoucher(_offerVoucherRepository.GetOfferVoucher(ReedemOfferVoucher_5_off_Over50_Id));
        }
        /// <summary>
        /// 
        /// </summary>
        [When(@"I calls GetBasketTotalAmount\(\)")]
        public void WhenICallsGetBasketTotalAmount()
        {
            _result = _basketService.GetBasketTotalAmount(_shoppingBasket);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="total"></param>
        [Then(@"I should see overalls price is £(.*)")]
        public void ThenIShouldSeeOverallsPriceIs(decimal total)
        {
            _result.BasketTotalAmount.Should().Be(total);
        }
        /// <summary>
        /// 
        /// </summary>
        [Then(@"Message: “There are no products in your basket applicable to Offer Voucher YYY-YYY\.”")]
        public void ThenMessageThereAreNoProductsInYourBasketApplicableToOfferVoucherYYY_YYY_()
        {
            _result.Notifications.Aggregate((i, j) => i + j).Should().Be("There are no products in your basket applicable to Offer Voucher YYY-YYY.");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="additional"></param>
        /// <param name="dicount"></param>
        [Then(@"Message: “You have not reached the spend threshold for Gift Voucher YYY-YYY\. Spend another £(.*) to receive £(.*) discount from your basket total\.”")]
        public void ThenMessageYouHaveNotReachedTheSpendThresholdForGiftVoucherYYY_YYY_SpendAnotherToReceiveDiscountFromYourBasketTotal_(decimal additional, decimal dicount)
        {
            _result.Notifications.Aggregate((i, j) => i +  j).Should().Be($"You have not reached the spend threshold for Gift Voucher YYY-YYY. Spend another £{additional} to receive £{dicount} discount from your basket total.");
        }

    }
}
