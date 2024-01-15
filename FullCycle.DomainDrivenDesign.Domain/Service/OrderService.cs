using FullCycle.DomainDrivenDesign.Domain.Entity;

namespace FullCycle.DomainDrivenDesign.Domain.Service;


public class OrderService
{
    public static decimal CalculateTotalOrders(Order[] orders)
    => orders.Sum(order => order.GetTotal());

    public static Order PlaceOrder(Customer customer, OrderItem[] orderItems)
    {
        if (!orderItems.Any())
            throw new ArgumentException("Itens must have at less one item");

        var id = new Random();
        var order = new Order(Guid.NewGuid().ToString(), customer.Id, orderItems);
        customer.addRewardsPoits(Convert.ToInt32(order.GetTotal() * 0.5m));
        return order;
    }
}