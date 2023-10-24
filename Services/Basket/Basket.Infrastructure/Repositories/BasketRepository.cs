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

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly RedisContext _redisContext;
        public BasketRepository(RedisContext redisContext)
        {
            _redisContext = redisContext;
        }

        public async Task<Response<bool>> Delete(string userId)
        {
            var status = await _redisContext.Database().KeyDeleteAsync(userId);
            return status ? Response<bool>.Success((int)HttpStatusCode.NoContent) : Response<bool>.Fail("Sepet bilgisi bulunamadı.", (int)HttpStatusCode.NotFound);
        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
            var existBasket = await _redisContext.Database().StringGetAsync(userId);
            if (string.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail("Sepet bilgisi bulunamadı.", (int)HttpStatusCode.NotFound);
            }
            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), (int)HttpStatusCode.OK);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisContext.Database().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
            return status ? Response<bool>.Success((int)HttpStatusCode.NoContent) : Response<bool>.Fail("Sepet bilgisi güncellenemedi.", (int)HttpStatusCode.InternalServerError);
        }
    }
}
