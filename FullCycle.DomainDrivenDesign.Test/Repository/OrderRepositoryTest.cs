using System.Data;
using FullCycle.DomainDrivenDesign.Domain.Checkout.Entity;
using FullCycle.DomainDrivenDesign.Domain.Customers.Entity;
using FullCycle.DomainDrivenDesign.Domain.Customers.ValueObject;
using FullCycle.DomainDrivenDesign.Domain.Products.Entity;
using FullCycle.DomainDrivenDesign.Infra.Checkout.Repository.EntityFrameworkCore;
using FullCycle.DomainDrivenDesign.Infra.Customers.Repository.EntityFrameworkCore;
using FullCycle.DomainDrivenDesign.Infra.Products.Repository.EntityFrameworkCore;
using FullCycle.DomainDrivenDesign.Infra.Shared.Database.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullCycle.DomainDrivenDesign.Test.Repository;

[TestClass]
public class OrderRepositoryTest
{
    private static DbContextOptions<DatabaseContext> options;
    public OrderRepositoryTest()
    {
        options = new DbContextOptionsBuilder<DatabaseContext>()
                 .UseInMemoryDatabase("DatabaseInMemoryTest")
                 .Options;
    }

    [TestMethod]
    public async Task CreateOrder_ExecuteAsExpected()
    {
        var customerId = Guid.NewGuid().ToString();
        var customer = new Customer(customerId, "Customer1");
        var address = new Address("Street", "123", "123456789", "NY");
        var newAdress = new Address("Rua", "321", "4984", "Miami");
        customer.setAddress(address);
        var product1 = new Product(Guid.NewGuid().ToString(), "Product 1", 10);
        var product2 = new Product(Guid.NewGuid().ToString(), "Product 2", 10);

        var orderItem1 = new OrderItem(Guid.NewGuid().ToString(), "ITem 1", Convert.ToDecimal(product1.Price), product1.Id, 2);
        var orderItem2 = new OrderItem(Guid.NewGuid().ToString(), "ITem 1", Convert.ToDecimal(product2.Price), product2.Id, 4);
        var orderId = Guid.NewGuid().ToString();
        var order = new Order(orderId, customerId, new OrderItem[] { orderItem1, orderItem2 });

        Order orderExpected;
        using (var context = new DatabaseContext(options))
        {
            var customerRepository = new CustomerRepository(context);
            await customerRepository.CreateAsync(customer);

            var productRepository = new ProductRepository(context);
            await productRepository.CreateAsync(product1);
            await productRepository.CreateAsync(product2);


            var orderRepository = new OrderRepository(context);
            await orderRepository.CreateAsync(order);

            orderExpected = await orderRepository.GetFindAsync(orderId);
        }

        Assert.IsNotNull(orderExpected);
        Assert.AreEqual(2, order.Itens.Count());
    }



}