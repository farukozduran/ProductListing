using Microsoft.AspNetCore.Mvc;
using ProductListing.Application.Common.Responses;
using ProductListing.Application.DTOs;
using ProductListing.Application.Interfaces;
using ProductListing.Application.Mappings;

namespace ProductListing.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IPricingService _pricingService;

        public ProductController(IProductService productService, IPricingService pricingService)
        {
            _productService = productService;
            _pricingService = pricingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] decimal? minPopularity)
        {
            var products = await _productService.GetProductsAsync(
                minPrice,
                maxPrice,
                minPopularity);

            var result = products
                .Select(p => ProductMapper.ToDto(p, _pricingService))
                .ToList();

            return Ok(ApiResponse<List<ProductDto>>.SuccessResponse(result));
        }
    }
}
