using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace RedisLessons.IDistributedCacheRedisApp.Controllers
{
    public class ProductsController : Controller
    {
        private IDistributedCache _distributedCache;

        public ProductsController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<IActionResult> Index()
        {
            DistributedCacheEntryOptions cacheEntryOptions = new DistributedCacheEntryOptions();

            cacheEntryOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(1);

            await _distributedCache.SetStringAsync("name", "Firat", cacheEntryOptions);
            return View();
        }

        public IActionResult Show() 
        {
            ViewBag.Show = _distributedCache.GetString("name");
            return View();
        }

        public IActionResult Delete() 
        {
            _distributedCache.Remove("name");
            return View();
        }
    }
}
