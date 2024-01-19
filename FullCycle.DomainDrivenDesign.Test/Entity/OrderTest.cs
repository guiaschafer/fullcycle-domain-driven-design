using FullCycle.DomainDrivenDesign.Domain.Checkout.Entity;

namespace FullCycle.DomainDrivenDesign.Test.Entity;

[TestClass]
public class OrderTest
{
    [TestMethod]
    public void CreateOrderWithoutIdShouldThrowError()
    {
        var act = () => new Order("0", "0", null);
        Assert.ThrowsException<ArgumentNullException>(act);
    }

    [TestMethod]
    public void CreateOrderWithoutCustomerIdShouldThrowError()
    {
        var act = () => new Order("1", "0", null);
        Assert.ThrowsException<ArgumentNullException>(act);
    }

    [TestMethod]
    public void CreateOrderWithoutItensShouldThrowError()
    {
        var act = () => new Order("1", "1", null);
        var act2 = () => new Order("1", "1", new OrderItem[] { });
        Assert.ThrowsException<ArgumentNullException>(act, "Itens is required");
        Assert.ThrowsException<ArgumentNullException>(act2, "Itens is required");
    }

    [TestMethod]
    public void CalculateTotalCorrectly()
    {
        var order = new Order("1", "1", new OrderItem[]
        {
            new OrderItem("1","item 1",10, "1", 2),
            new OrderItem("2","item 2",30, "2", 2),
        });

        Assert.AreEqual(80m, order.GetTotal());
    }

    [TestMethod]
    public void CreateOrderWithPriceItemZeroShouldThrowError()
    {
        var act = () => new Order("1"," 1", new OrderItem[]
        {
            new OrderItem("1","item 1",0, "1", 1),
            new OrderItem("2","item 2",0, "2", 1),
        });

        var exception = Assert.ThrowsException<ArgumentException>(act);
        Assert.AreEqual("Price should be greater than zero.", exception.Message);
    }

    [TestMethod]
    public void CreateOrderWithQuantityItemZeroShouldThrowError()
    {
        var act = () => new Order("1"," 1", new OrderItem[]
        {
            new OrderItem("1","item 1",10, "1", 2),
            new OrderItem("2","item 2",10, "2", -1),
        });

        var exception = Assert.ThrowsException<ArgumentException>(act);
        Assert.AreEqual("Quantity should be greater than zero.", exception.Message);
    }
}