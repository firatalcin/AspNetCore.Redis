using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace RedisLessons.InMemoryApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public ProductsController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            ////1.yol
            //if (String.IsNullOrEmpty(_memoryCache.Get<string>("zaman")))
            //{
            //    _memoryCache.Set<string>("zaman", DateTime.Now.ToString());
            //}


            //2.yol

            MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions();
            // Bir dakika sonra silinir
            cacheOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(1);
            // Her istekte 10 saniye yenilenir
            cacheOptions.SlidingExpiration = TimeSpan.FromSeconds(10);
            // Cache'in önemi
            cacheOptions.Priority = CacheItemPriority.High;

            _memoryCache.Set<string>("zaman", DateTime.Now.ToString(), cacheOptions);

            return View();
        }

        public IActionResult Show()
        {
            //_memoryCache.GetOrCreate<string>("zaman", entry =>
            //{
            //    return DateTime.Now.ToString();
            //});

            _memoryCache.TryGetValue("zaman", out string zamancache);

            //ViewBag.Zaman = _memoryCache.Get<string>("zaman");

            ViewBag.Zaman = zamancache;

            return View();
        }
    }
}
