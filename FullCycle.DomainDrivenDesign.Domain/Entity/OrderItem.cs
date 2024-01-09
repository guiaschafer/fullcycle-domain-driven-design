
namespace FullCycle.DomainDrivenDesign.Domain.Entity;

public class OrderItem
{
    private int Id;
    private int ProductId;
    private string Name;
    public decimal Price { private set; get; }
    public int Quantity { private set; get; }

    public OrderItem(int id, string name, decimal price, int productId, int quantity)
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