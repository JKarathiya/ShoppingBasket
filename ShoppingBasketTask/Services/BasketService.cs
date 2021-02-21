using ShoppingBasketTask.Models;
using ShoppingBasketTask.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace ShoppingBasketTask.Services
{
    public class BasketService
    {
        private const bool _success = true;
        private readonly IShoppingBasketProcessorFactory _basketProcessorFactory;
        private readonly Mapper _mapper;

        public BasketService(IShoppingBasketProcessorFactory basketProcessorFactory)
        {
            _basketProcessorFactory = basketProcessorFactory;
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<BasketResponse, BasketServiceResponse>()));
        }

        public BasketServiceResponse GetBasketTotalAmount(IShoppingBasket shoppingBasket)
        {

            if (shoppingBasket.GetBasketItems().Any())
            {
                foreach (var processor in CreateBasketProcessors())
                {
                    processor.Process(shoppingBasket);
                }
                return _mapper.Map<BasketServiceResponse>(new BasketResponse
                {
                    Notifications = shoppingBasket.Messages?.ToList(),
                    BasketTotalAmount = shoppingBasket.Total,
                    Success = _success
                });
            }

            return _mapper.Map<BasketServiceResponse>(new BasketResponse()
            {
                Notifications = new List<string> { "Your Shopping Basket is empty" },
                Success = _success,
                BasketTotalAmount = 0.0m
            });
        }

        private IList<IShoppingBasketProcessor> CreateBasketProcessors()
        {
            return new List<IShoppingBasketProcessor>
            {
                _basketProcessorFactory.CreateProductProcessor(),
                _basketProcessorFactory.CreateOfferVoucherProcessor(),
                _basketProcessorFactory.CreateGiftVoucherProcessor(),
            };
        }
    }
}
