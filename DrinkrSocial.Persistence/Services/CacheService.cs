using DrinkrSocial.Application.Interfaces.Services;
using EasyCaching.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Persistence.Services
{
    public class CacheService : ICacheService
    {
        private readonly IEasyCachingProvider _easyCachingProvider;

        public CacheService(IEasyCachingProvider cachingProvider)
        {
            _easyCachingProvider = cachingProvider;
        }
        public async Task<object> GetAsync(string key, Type cachedData)
        {
            return await _easyCachingProvider.GetAsync(key, cachedData);
        }

        public async Task RemoveAsync(string key)
        {
            await _easyCachingProvider.RemoveAsync(key);
        }

        public async Task RemoveByPrefixAsync(string prefix)
        {
            await _easyCachingProvider.RemoveByPrefixAsync(prefix);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            if (expiration.HasValue)
            {
                await _easyCachingProvider.SetAsync(key, value, expiration.Value);
            }
            else
            {
                await _easyCachingProvider.SetAsync(key, value, TimeSpan.FromMinutes(10));
            }
        }
    }
}
