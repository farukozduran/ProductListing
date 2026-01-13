namespace ProductListing.Application.Interfaces
{
    public interface IPricingService
    {
        public Task<decimal> GetGoldPriceAsync();
        public decimal CalculatePrice(decimal popularityScore, decimal weight, decimal price);
    }
}
