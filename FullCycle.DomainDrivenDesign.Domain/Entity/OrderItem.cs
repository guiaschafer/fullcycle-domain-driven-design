namespace FullCycle.DomainDrivenDesign.Domain.Entity;

public class OrderItem
{
    private string Id;
    private string Name;
    public decimal Price { private set; get; }

    public OrderItem(string id, string name, decimal price)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
    }


}