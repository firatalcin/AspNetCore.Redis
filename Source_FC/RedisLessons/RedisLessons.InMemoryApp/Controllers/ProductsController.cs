﻿using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
    }
}