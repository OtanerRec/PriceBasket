using PriceBasket.Models;

namespace PriceBasket.Factories
{
    public static class ProductFactory
    {
        public static List<Product> InitializeProducts()
        {
            var availableProducts = new List<Product>()
            {
                new Product("apples", 1.00m),
                new Product("bread", 0.80m),
                new Product("milk", 1.30m),
                new Product("soup", 0.65m)
            };

            return availableProducts;
        }
        public static List<Product> CreateProduct(List<string> products, List<Product> availableProducts)
        {
            var productsSorted = products.OrderBy(q => q).ToList();
            var productsToBePurchased = new List<Product>();

            var productQuantity = 1;

            foreach (var productName in productsSorted)
            {
                var product = availableProducts.FirstOrDefault(p => p.Name == productName);

                if (product == null)
                {
                    throw new ArgumentException($"Invalid product name: {productName}");
                }
                else
                {
                    if (!productsToBePurchased.Any(p => p.Name == product.Name))
                        productsToBePurchased.Add(product);

                    product.AddQuantity(productQuantity);
                }
            }
            return productsToBePurchased;
        }
    }
}
