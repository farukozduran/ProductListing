using Microsoft.AspNetCore.Mvc;
using ProductListing.Application.Interfaces;

namespace ProductListing.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
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

            return Ok(products);
        }
    }
}
