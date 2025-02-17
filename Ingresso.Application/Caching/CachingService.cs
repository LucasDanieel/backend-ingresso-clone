using Ingresso.Application.Caching.Interfaces;
using StackExchange.Redis;

namespace Ingresso.Application.Caching
{
    public class CachingService : ICachingService
    {
        private readonly IDatabase _dbRedis;
        public CachingService(IConnectionMultiplexer redis) => _dbRedis = redis.GetDatabase();

        public async Task<string?> GetAsync(string key)
        {
            return await _dbRedis.StringGetAsync(key);
        }

        public async Task PostAsync(string key, string value)
        {
            await _dbRedis.StringSetAsync(key, value, TimeSpan.FromMinutes(15));
        }

        public async Task DeleteAsync(string key)
        {
            await _dbRedis.StringGetDeleteAsync(key);
        }
    }
}
