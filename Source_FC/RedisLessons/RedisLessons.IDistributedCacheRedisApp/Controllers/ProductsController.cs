using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RedisLessons.IDistributedCacheRedisApp.Models;
using System.Text.Json.Serialization;

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

        public async Task<IActionResult> IndexComplex() 
        {
            DistributedCacheEntryOptions cacheEntryOptions = new DistributedCacheEntryOptions();
            cacheEntryOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(1);

            Product product = new Product() { Id = 1, Name = "Kalem", Price = 100};

            string jsonProduct = JsonConvert.SerializeObject(product);

            await _distributedCache.SetStringAsync("product:1", jsonProduct, cacheEntryOptions);

            return View();
        }

        public IActionResult ShowComplex()
        {
            string json = _distributedCache.GetString("product:1");

            Product product = JsonConvert.DeserializeObject<Product>(json);
       
            return View(product);
        }

        public IActionResult DeleteComplex()
        {
            _distributedCache.Remove("name");
            return View();
        }

        public IActionResult ImageCache()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/bmw.jpg");

            byte[] imageByte = System.IO.File.ReadAllBytes(path);

            _distributedCache.Set("resim", imageByte);

            return View();
        }

        public IActionResult ImageShow()
        {
            byte[] imageByte = _distributedCache.Get("resim");

            return File(imageByte,"image/jpg");
        }
    }
}
