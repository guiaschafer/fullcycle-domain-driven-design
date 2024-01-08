using FullCycle.DomainDrivenDesign.Domain.Entity;

namespace FullCycle.DomainDrivenDesign.Test.Entity;

[TestClass]
public class OrderTest
{
    [TestMethod]
    public void CreateOrderWithoutIdShouldThrowError()
    {
        var act = () => new Order(0, 0, null);
        Assert.ThrowsException<ArgumentNullException>(act);
    }

    [TestMethod]
    public void CreateOrderWithoutCustomerIdShouldThrowError()
    {
        var act = () => new Order(1, 0, null);
        Assert.ThrowsException<ArgumentNullException>(act);
    }

    [TestMethod]
    public void CreateOrderWithoutItensShouldThrowError()
    {
        var act = () => new Order(1, 1, null);
        var act2 = () => new Order(1, 1, new OrderItem[] { });
        Assert.ThrowsException<ArgumentNullException>(act, "Itens is required");
        Assert.ThrowsException<ArgumentNullException>(act2, "Itens is required");
    }

    [TestMethod]
    public void CalculateTotalCorrectly()
    {
        var order = new Order(1, 1, new OrderItem[]
        {
            new OrderItem("1","item 1",10),
            new OrderItem("2","item 2",30),
        });

        Assert.AreEqual(40m, order.GetTotal());
    }
}