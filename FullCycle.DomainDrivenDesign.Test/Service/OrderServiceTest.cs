using FullCycle.DomainDrivenDesign.Domain.Entity;
using FullCycle.DomainDrivenDesign.Domain.Service;

namespace FullCycle.DomainDrivenDesign.Test.Service;

[TestClass]
public class OrderServiceTest
{

    [TestMethod]
    public void GetTotalOrders_ExecuteAsExpected()
    {
        var order1 = new Order(1, 1, new OrderItem[]
        {
            new OrderItem(1,"item 1",10, 1, 2),
            new OrderItem(2,"item 2",10, 2, 2),
        });

        var order2 = new Order(2, 1, new OrderItem[]
        {
            new OrderItem(1,"item 1",20, 1, 3),
            new OrderItem(2,"item 2",20, 2, 3),
        });

        var total = OrderService.CalculateTotalOrders(new Order[] { order1, order2 });

        Assert.AreEqual(160, total);
    }

    [TestMethod]
    public void PlaceOrder_ShouldHaveSomeRewardsPoints_ExecuteAsExpected()
    {
        var customer = new Customer(1, "Customer 1");
        var orderItems = new OrderItem[]
        {
            new OrderItem(1,"item 1",10, 1, 2),
            new OrderItem(2,"item 2",10, 2, 2),
        };

        var order = OrderService.PlaceOrder(customer, orderItems);

        Assert.AreEqual(20, customer.RewardsPoints);
    }

    [TestMethod]
    public void PlaceManyOrder_ShouldHaveRewardsPointsAccordingOrders_ExecuteAsExpected()
    {
        var customer = new Customer(1, "Customer 1");
        var orderItems = new OrderItem[]
        {
            new OrderItem(1,"item 1",10, 1, 2),
            new OrderItem(2,"item 2",10, 2, 2),
        };

        var order = OrderService.PlaceOrder(customer, orderItems);
        var order2 = OrderService.PlaceOrder(customer, orderItems);

        Assert.AreEqual(40, customer.RewardsPoints);
    }
}