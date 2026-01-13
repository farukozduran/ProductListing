using ProductListing.Domain.Models;

namespace ProductListing.Application.Interfaces
{
    public interface IProductService
    {
        public Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}
