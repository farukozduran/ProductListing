namespace ProductListing.Application.Interfaces
{
    public interface IPricingService
    {
        public Task<decimal> GetGoldPriceAsync();
        public decimal CalculatePrice(decimal popularityScore, decimal weight, decimal goldPrice);
        public decimal ConvertPopularityToFiveScale(decimal popularityScore);
        public decimal RoundPrice(decimal price);
    }
}
