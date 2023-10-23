using Basket.Infrastructure.Interfaces;
using Basket.Infrastructure.Redis;
using Microservice.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
            return status ? Response<bool>.Success((int)HttpStatusCode.NoContent) : Response<bool>.Fail("Sepet bilgisi bulunamadı", (int)HttpStatusCode.NotFound);
        }
    }
}
