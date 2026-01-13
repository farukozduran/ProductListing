using ProductListing.Application.Interfaces;

namespace ProductListing.Application.Services
{
    public class PricingService : IPricingService
    {

        public async Task<decimal> GetGoldPriceAsync() 
        {
            await Task.Delay(50);
            return 70.5m;
        }

        public decimal CalculatePrice(decimal popularityScore, decimal weight, decimal goldPrice) 
        {
            return (popularityScore + 1) * weight * goldPrice;
        }

        public decimal ConvertPopularityToFiveScale(decimal popularityScore)
        {
            return Math.Round(popularityScore * 5, 1);
        }

        public decimal RoundPrice(decimal price)
        {
            return Math.Round(price, 2);
        }
    }
}
