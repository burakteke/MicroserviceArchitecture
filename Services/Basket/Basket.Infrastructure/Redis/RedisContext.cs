using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Infrastructure.Redis
{
    public class RedisContext
    {
        private readonly string _host;
        private readonly int _port;
        private ConnectionMultiplexer _connection;
        public IDatabase Database(int db = 1) => _connection.GetDatabase(db);

        public RedisContext(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connection = ConnectionMultiplexer.Connect($"{_host}:{_port}");
    }
}
