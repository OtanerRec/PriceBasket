namespace PriceBasket.Models
{
    public class Product : Entity
    {
        public Product(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;

            this.IsValid();
        }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;

            this.IsValid();
        }

        public string Name { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }

        public bool IsValid()
        {
            if(Name.Length == 0) return false;
            if(Price == 0) return false;

            return true;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}