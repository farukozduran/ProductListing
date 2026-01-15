using Newtonsoft.Json;
using ProductListing.Application.DTOs;
using ProductListing.Application.Interfaces;
using ProductListing.Application.Mappings;
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

        public async Task<IReadOnlyList<ProductDto>> GetProductsAsync(
            decimal? minPrice,
            decimal? maxPrice,
            decimal? minPopularity) 
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Data", "products.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("products.json not found!");
            }

            var json = await File.ReadAllTextAsync(filePath);
            var products = JsonConvert.DeserializeObject<List<Product>>(json) 
                ?? new List<Product>();

            var goldPrice = await _pricingService.GetGoldPriceAsync();

            foreach(var product in products)
            {
                product.Price = _pricingService.CalculatePrice(
                    product.PopularityScore,
                    product.Weight,
                    goldPrice);
            }

            // FILTERING ON DOMAIN

            if (minPrice.HasValue)
            {
                products = products
                    .Where(p => p.Price >= minPrice.Value)
                    .ToList();
            }

            if (maxPrice.HasValue)
            {
                products = products
                    .Where(p => p.Price <= maxPrice.Value)
                    .ToList();
            }

            if (minPopularity.HasValue)
            {
                products = products
                    .Where(p =>
                        _pricingService.ConvertPopularityToFiveScale(p.PopularityScore)
                        >= minPopularity.Value)
                    .ToList();
            }

            return products
                .Select(p => ProductMapper.ToDto(p, _pricingService))
                .ToList();
            
        }
    }
}
