using PriceBasket.Discounts.Implementations;
using PriceBasket.Factories;
using PriceBasket.Models;

class program
{
    static void Main(string[] args)
    {
        Console.WriteLine("***BJSS Challenge***");

        if (args == null)
        {
            Console.WriteLine("Your basket is empty!");
        }
        else
        {
            try
            {
                var productsToBeSold = ProductFactory.InitializeProducts();

                var products = new List<string>();

                for (int i = 0; i < args.Length; i++)
                {
                    products.Add(args[i].ToLower());
                }

                var productsBasket = new Basket();

                productsBasket.AddProducts(ProductFactory.CreateProduct(products, productsToBeSold));

                var subTotal = productsBasket.CalcSubTotal();

                var discountService = new DiscountService();

                var discounts = discountService.DiscountCalculation(productsBasket.Products);

                productsBasket.AddDiscount(discounts);

                var total = productsBasket.CalcTotal();

                foreach (var disc in discounts)
                {
                    Console.WriteLine(disc.DiscountDescription);
                }

                Console.WriteLine("SubTotal: " + $"{subTotal}");
                Console.WriteLine("Total: " + $"{total}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }
    }
}
