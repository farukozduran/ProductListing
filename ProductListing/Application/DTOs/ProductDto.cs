namespace ProductListing.Application.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal PopularityScore { get; set; }
        public ProductImageDto? Images { get; set; }
    }

    public class ProductImageDto
    {
        public string Yellow { get; set; } = string.Empty;
        public string Rose { get; set; } = string.Empty;
        public string White { get; set; } = string.Empty;
    }
}
