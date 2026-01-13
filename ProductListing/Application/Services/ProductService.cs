using Newtonsoft.Json;
using ProductListing.Application.Interfaces;
using ProductListing.Domain.Models;

namespace ProductListing.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IPricingService _pricingService;
        private readonly IWebHostEnvironment _env;

        public ProductService(IPricingService pricingService, IWebHostEnvironment env)
        {
            _pricingService = pricingService;
            _env = env;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync() 
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Data", "products.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("products.json not found!");
            }

            var json = await File.ReadAllTextAsync(filePath);

            var products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();

            var goldPrice = await _pricingService.GetGoldPriceAsync();

            foreach(var product in products)
            {
                product.Price = _pricingService.CalculatePrice(
                    product.PopularityScore,
                    product.Weight,
                    goldPrice);
            }

            return products;
            
        }
    }
}
