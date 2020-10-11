//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
//using Microsoft.Extensions.Caching.Distributed;
//using Microsoft.Extensions.Caching.Memory;

//namespace ValidationAndError
//{
//    public class CacheManager
//    {
//        private readonly IDistributedCacheTagHelperService _tagHelper;
//        private readonly IDistributedCache _cache;
//        private readonly IMemoryCache _memCache;

//        public CacheManager(IDistributedCacheTagHelperService tagHelper, IDistributedCache cache, IMemoryCache memCache)
//        {
//            _tagHelper = tagHelper;
//            _cache = cache;
//            _memCache = memCache;
//        }

//        public void test()
//        {
//            Func<Task<List<Show>>> showObjectFactory = () => PopulateShowsCache();
//            _cache.SetString("fsd","fsdf");
//            _memCache.GetOrCreate("josjdf",)
//        }
//    }
//}