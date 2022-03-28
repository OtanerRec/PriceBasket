namespace PriceBasket.Models
{
    public class Basket : Entity
    {
        private readonly List<Product> products;
        private readonly List<Discount> discounts;

        public Basket()
        {
            this.products = new List<Product>();
            this.discounts = new List<Discount>();
        }

        public decimal SubTotal { get; private set; }

        public decimal Total { get; private set; }

        public Product? Product { get; private set; }

        public Discount? Discount { get; private set; }

        public IReadOnlyCollection<Product> Products => products;

        public IReadOnlyCollection<Discount> Discounts => discounts;

        public void AddProducts(List<Product> products)
        {
            this.products.AddRange(products);
        }

        public decimal CalcSubTotal()
        {
            this.SubTotal = this.Products.Sum(p => p.Quantity * p.Price);
            return this.SubTotal;
        }

        public decimal CalcTotal()
        {
            this.Total = this.SubTotal - this.Discounts.Sum(d => d.DiscountValue);
            return this.Total;
        }

        public void AddDiscount(List<Discount> discountValues)
        {
            this.discounts.AddRange(discountValues);
        }
    }
}
