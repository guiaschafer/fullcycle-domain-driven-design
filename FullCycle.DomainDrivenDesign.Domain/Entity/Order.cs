
namespace FullCycle.DomainDrivenDesign.Domain.Entity;

public class Order
{
    private int Id;
    private int CustomerId;
    private decimal Total;
    private OrderItem[] Itens;

    public Order(int id, int customerId, OrderItem[] itens)
    {
        this.Id = id;
        this.CustomerId = customerId;
        this.Itens = itens;
        this.Total = this.GetTotal();
        Validate();
    }

    private void Validate()
    {
        if (this.Id <= 0)
            throw new ArgumentNullException("Id is required");
        if (this.CustomerId <= 0)
            throw new ArgumentNullException("CustomerId is required");
        if (this.Itens == null || !this.Itens.Any())
            throw new ArgumentNullException("Itens is required");

    }

    public decimal GetTotal() => this.Itens.Aggregate(0m, (value, next) => value + (next.Price * next.Quantity));
}