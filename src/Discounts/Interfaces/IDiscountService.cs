using PriceBasket.Models;

namespace PriceBasket.Discounts.Interfaces
{
    public interface IDiscountService
    {
        List<Discount> DiscountCalculation(IEnumerable<Product> products);
    }
}