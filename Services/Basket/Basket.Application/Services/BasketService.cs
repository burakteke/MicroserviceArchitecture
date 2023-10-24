using Basket.Application.Interfaces;
using Basket.Domain.Entities;
using Basket.Infrastructure.Interfaces;
using Basket.Infrastructure.Redis;
using Microservice.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Basket.Application.Services
{
    public class BasketService: IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<Response<bool>> Delete(string userId)
        {
            return await _basketRepository.Delete(userId);
        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
            return await _basketRepository.GetBasket(userId);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            return await _basketRepository.SaveOrUpdate(basketDto);
        }
    }
}
