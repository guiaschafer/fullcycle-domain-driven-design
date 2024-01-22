using FullCycle.DomainDrivenDesign.Domain.Checkout.Entity;

namespace FullCycle.DomainDrivenDesign.Domain.Checkout.Factory;

public class OrderFactory
{
    public static Order Create(OrderFactoryProps props)
    {
        ICollection<OrderItem> items = new List<OrderItem>();
        foreach (var item in props.Items)
        {   
            var newItem = new OrderItem(item.Id,item.Name, item.Price, item.ProductId,item.Quantity);
            items.Add(newItem);            
        }

        return new Order(props.Id, props.CustomerId, items.ToArray());    }
}

public class OrderFactoryProps
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public OrderItemProps[] Items { get; set; }

}

public class OrderItemProps
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
