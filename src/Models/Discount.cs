namespace PriceBasket.Models
{
    public class Discount
    {
        public decimal DiscountValue { get; private set; }

        public string DiscountDescription { get; private set; }

        public void CreateDiscount(decimal discountvalue, string discountDescription)
        {
            this.DiscountValue = discountvalue;
            this.DiscountDescription = discountDescription;
        }
    }
}
