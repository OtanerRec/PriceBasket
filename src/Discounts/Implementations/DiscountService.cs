using PriceBasket.Discounts.Interfaces;
using PriceBasket.Models;

namespace PriceBasket.Discounts.Implementations
{
    public class DiscountService : IDiscountService
    {
        public List<Discount> DiscountCalculation(IEnumerable<Product> products)
        {
            var countBreads = 0;
            var productToBeDiscounted = products.Where(x => x.Name.ToLower() == "bread").FirstOrDefault();
            var discountList = new List<Discount>();

            var discountValue = 0.0m;
            var discountDescription = "";

            foreach (var product in products)
            {
                var discount = new Discount();

                switch (product.Name.ToLower())
                {
                    case "apples":
                        discountValue = Math.Round((product.Price * product.Quantity) * .10m, 2);
                        discountDescription = "Apples 10% OFF: -" + $"{ discountValue}";
                        discount.CreateDiscount(discountValue, discountDescription);
                        discountList.Add(discount);
                        break;
                    case "bread":
                        countBreads++;
                        break;
                    case "soup":
                        if (product.Quantity % 2 == 0 && countBreads != 0)
                        {
                            discountValue = productToBeDiscounted.Price / 2;
                            discountDescription = "Bread 50% OFF: -" + $"{ discountValue}";
                            discount.CreateDiscount(discountValue, discountDescription);
                            discountList.Add(discount);
                            break;
                        }
                        discountValue = 0;
                        discountDescription = "(no offers available)";
                        break;
                    default:
                        discountValue = 0;
                        discountDescription = "(no offers available)";
                        break;
                }
            }
            return discountList;
        }
    }
}
