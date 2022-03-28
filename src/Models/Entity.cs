namespace PriceBasket.Models
{
    //Abstract class cannot be instanciated. Just inherit
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
