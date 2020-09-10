using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OrchardCore.Environment.Cache;
using OrchardCore.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DojoCourse.Module.Controllers
{
    public class CacheController : Controller
    {
        private const string CacheKey = "DojoCourse.Module.CacheController.DemoCacheEntry";
        private const string SignalKey = "DojoCourse.Module.CacheController.DemoSignal";

        private readonly IMemoryCache _memoryCache;
        private readonly ILocalClock _localClock;
        private readonly ISignal _signal;


        public CacheController(IMemoryCache memoryCache, ILocalClock localClock, ISignal signal)
        {
            _memoryCache = memoryCache;
            _localClock = localClock;
            _signal = signal;
        }


        public async Task<string> ReadCache()
        {
            DateTimeOffset localTime;

            if (!_memoryCache.TryGetValue(CacheKey, out localTime))
            {
                localTime = _memoryCache.Set(CacheKey, await _localClock.LocalNowAsync, _signal.GetToken(SignalKey));
            }

            return localTime.ToString();
        }

        public string InvalidateCache()
        {
            _memoryCache.Remove(CacheKey);
            return "OK";
        }

        public string InvalidateCacheWithSignal()
        {
            _signal.SignalToken(SignalKey);
            return "OK";
        }
    }
}
