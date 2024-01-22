using FullCycle.DomainDrivenDesign.Domain.Checkout.Factory;

namespace FullCycle.DomainDrivenDesign.Test.Factory;

[TestClass]
public class OrderFactoryTest
{
    [TestMethod]
    public void CreateOrder_ExecuteAsExpected()
    {
        var orderProps = new OrderFactoryProps()
        {
            Id = Guid.NewGuid().ToString(),
            CustomerId = Guid.NewGuid().ToString(),
            Items = new OrderItemProps[]{
                new OrderItemProps(){
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product 1",
                    ProductId = Guid.NewGuid().ToString(),
                    Quantity = 1,
                    Price = 100
                }
            }
        };

        var order = OrderFactory.Create(orderProps);

        Assert.AreEqual(orderProps.Id, order.Id);
        Assert.AreEqual(orderProps.CustomerId, order.CustomerId);
        Assert.AreEqual(orderProps.Items.Length, order.Itens.Length);
    }
}