
namespace FullCycle.DomainDrivenDesign.Domain.Entity;

public class Order
{
    public string Id {private set; get;}
    public string CustomerId  {private set; get;}
    public decimal Total  {private set; get;}
    public OrderItem[] Itens  {private set; get;}

    public Order(string id, string customerId, OrderItem[] itens)
    {
        this.Id = id;
        this.CustomerId = customerId;
        this.Itens = itens;
        this.Total = this.GetTotal();
        Validate();
    }

    private void Validate()
    {
        if (String.IsNullOrEmpty(this.Id))
            throw new ArgumentNullException("Id is required");
        if (String.IsNullOrEmpty(this.CustomerId))
            throw new ArgumentNullException("CustomerId is required");
        if (this.Itens == null || !this.Itens.Any())
            throw new ArgumentNullException("Itens is required");

    }

    public decimal GetTotal() => this.Itens.Aggregate(0m, (value, next) => value + (next.Price * next.Quantity));
}