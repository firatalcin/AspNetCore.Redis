using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RedisLessons.InMemoryApp.Models;

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
            // Cache silindiği zaman hangi sebeple silindiğini yazar
            cacheOptions.RegisterPostEvictionCallback((key, value, reason, state) => {

                _memoryCache.Set("callback", $"{key}->{value} => sebep:{reason}");
            
            });

            _memoryCache.Set<string>("zaman", DateTime.Now.ToString(), cacheOptions);

            Product product = new Product() { Id = 1, Name = "Kalem", Price = 100};

            _memoryCache.Set<Product>("product:1", product);

            return View();
        }

        public IActionResult Show()
        {
            //_memoryCache.GetOrCreate<string>("zaman", entry =>
            //{
            //    return DateTime.Now.ToString();
            //});

            _memoryCache.TryGetValue("zaman", out string zamancache);
            _memoryCache.TryGetValue("callback", out string callback);

            //ViewBag.Zaman = _memoryCache.Get<string>("zaman");

            ViewBag.Zaman = zamancache;
            ViewBag.Callback = callback;

            ViewBag.Product = _memoryCache.Get<Product>("product:1");

            return View();
        }
    }
}
