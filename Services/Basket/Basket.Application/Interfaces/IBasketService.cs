using Basket.Domain.Entities;
using Microservice.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Interfaces
{
    public interface IBasketService
    {
        Task<Response<bool>> Delete(string userId);
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
    }
}
