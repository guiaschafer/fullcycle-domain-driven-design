
namespace FullCycle.DomainDrivenDesign.Domain.Checkout.Entity;

public class OrderItem
{
    public string Id { private set; get; }
    public string ProductId { private set; get; }
    public string Name { private set; get; }
    public decimal Price { private set; get; }
    public int Quantity { private set; get; }

    public OrderItem(string id, string name, decimal price, string productId, int quantity)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.ProductId = productId;
        this.Quantity = quantity;

        Validate();
    }

    private void Validate()
    {
        if (this.Price <= 0)
            throw new ArgumentException("Price should be greater than zero.");
        if (this.Quantity <= 0)
            throw new ArgumentException("Quantity should be greater than zero.");
    }
}