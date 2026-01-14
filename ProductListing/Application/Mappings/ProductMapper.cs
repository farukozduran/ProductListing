using ProductListing.Application.DTOs;
using ProductListing.Application.Interfaces;
using ProductListing.Domain.Models;

namespace ProductListing.Application.Mappings
{
    public class ProductMapper
    {
        public static ProductDto ToDto(Product product, IPricingService pricingService) 
        {
            return new ProductDto
            {
                Name = product.Name,
                Price = pricingService.RoundPrice(product.Price),
                PopularityScore = pricingService.ConvertPopularityToFiveScale(product.PopularityScore),
                Images = new ProductImageDto
                {
                    Yellow = product.Images.Yellow,
                    Rose = product.Images.Rose,
                    White = product.Images.White
                }
            };
        }
    }
}
