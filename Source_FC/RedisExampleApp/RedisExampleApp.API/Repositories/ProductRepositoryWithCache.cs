using RedisExampleApp.API.Models;
using RedisExampleApp.Cache;
using StackExchange.Redis;
using System.Text.Json;

namespace RedisExampleApp.API.Repositories
{
	public class ProductRepositoryWithCache : IProductRepository
	{
		private const string productKey = "productCaches";
		private readonly IProductRepository _repository;
		private readonly RedisService _redisService;
		private readonly IDatabase _redisDatabase;

		public ProductRepositoryWithCache(IProductRepository repository, RedisService redisService)
		{
			_repository = repository;
			_redisService = redisService;
			_redisDatabase = _redisService.GetDb(2);
		}

		public async Task<Product> CreateAsync(Product product)
		{
			var p = await _repository.CreateAsync(product);

			if(await _redisDatabase.KeyExistsAsync(productKey))
			{
				await _redisDatabase.HashSetAsync(productKey, product.Id, JsonSerializer.Serialize(p));
			}

			return p;
		}

		public async Task<List<Product>> GetAsync()
		{
			if (!await _redisDatabase.KeyExistsAsync(productKey))
			{
				return await LoadToCacheFromDbAsync();
			}

			var products = new List<Product>();
			var cacheProduct = await _redisDatabase.HashGetAllAsync(productKey);
            foreach (var item in cacheProduct.ToList())
            {
				var product = JsonSerializer.Deserialize<Product>(item.Value);
				products.Add(product);
            }

			return products;
        }

		public async Task<Product> GetByIdAsync(int id)
		{
			if(await _redisDatabase.KeyExistsAsync(productKey))
			{
				var product = await _redisDatabase.HashGetAsync(productKey, id);
				return product.HasValue ? JsonSerializer.Deserialize<Product>(product) : null;
			}

			var products = await LoadToCacheFromDbAsync();

			return products.FirstOrDefault(x => x.Id == id);
		}

		private async Task<List<Product>> LoadToCacheFromDbAsync()
		{
			var product = await _repository.GetAsync();

			product.ForEach(p =>
			{
				_redisDatabase.HashSetAsync(productKey, p.Id, JsonSerializer.Serialize(p));
			});

			return product;
		} 
	}
}
