namespace ProductListing.Domain.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal PopularityScore { get; set; }
        public decimal Weight { get; set; }
        public ProductImage Images { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductImage 
    {
        public string Yellow { get; set; } = string.Empty;
        public string Rose { get; set; } = string.Empty;
        public string White { get; set; } = string.Empty;
    }
}
