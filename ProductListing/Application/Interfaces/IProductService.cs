using ProductListing.Application.DTOs;

namespace ProductListing.Application.Interfaces
{
    public interface IProductService
    {
        public Task<IReadOnlyList<ProductDto>> GetProductsAsync();
    }
}
