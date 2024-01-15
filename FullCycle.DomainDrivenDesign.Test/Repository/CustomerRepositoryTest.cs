using System.Data;
using FullCycle.DomainDrivenDesign.Domain.Entity;
using FullCycle.DomainDrivenDesign.Infra.Database;
using FullCycle.DomainDrivenDesign.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace FullCycle.DomainDrivenDesign.Test.Repository;

[TestClass]
public class CustomerRepositoryTest
{
    private static DbContextOptions<DatabaseContext> options;
    public CustomerRepositoryTest()
    {
        options = new DbContextOptionsBuilder<DatabaseContext>()
                 .UseInMemoryDatabase("DatabaseInMemoryTest")
                 .Options;
    }

    [TestMethod]
    public async Task CreateCustomerInDb_ExecuteAsExpected()
    {
        var customerId = Guid.NewGuid().ToString();
        var customer = new Customer(customerId, "Customer1");
        var address = new Address("Street", "123", "123456789", "NY");
        customer.setAddress(address);

        Customer customerExpected;
        using (var context = new DatabaseContext(options))
        {
            var repository = new CustomerRepository(context);
            await repository.CreateAsync(customer);

            customerExpected = await repository.GetFindAsync(customerId);
        }

        Assert.IsTrue(customer.Equals(customerExpected));
    }

    [TestMethod]
    public async Task UpdateCustomerInDb_ExecuteAsExpected()
    {
        var customerId = Guid.NewGuid().ToString();
        var customer = new Customer(customerId, "Customer1");
        var address = new Address("Street", "123", "123456789", "NY");
        var newAdress = new Address("Rua", "321", "4984", "Miami");
        customer.setAddress(address);

        Customer customerExpected;
        using (var context = new DatabaseContext(options))
        {
            var repository = new CustomerRepository(context);
            await repository.CreateAsync(customer);

            customer.changeName("Customer 2");
            customer.setAddress(newAdress);

            await repository.UpdateAsync(customer);


            customerExpected = await repository.GetFindAsync(customerId);
        }

        Assert.AreEqual("Customer 2", customerExpected.Name);
        Assert.IsTrue(newAdress.Equals(customerExpected.Address.Value));
    }

    [TestMethod]
    public async Task FindCustomerInDb_ExecuteAsExpected()
    {
        var customerId = Guid.NewGuid().ToString();
        var customer = new Customer(customerId, "Customer1");
        var address = new Address("Street", "123", "123456789", "NY");
        var newAdress = new Address("Rua", "321", "4984", "Miami");
        customer.setAddress(address);

        Customer customerExpected;
        using (var context = new DatabaseContext(options))
        {
            var repository = new CustomerRepository(context);
            await repository.CreateAsync(customer);

            customerExpected = await repository.GetFindAsync(customerId);
        }

        Assert.AreEqual(customer, customerExpected);
        Assert.IsTrue(customer.Equals(customerExpected));
    }

    [TestMethod]
    public async Task TryToFindCustomerInDb_ShouldThrowException_NotFoundCustomer()
    {
        var customerId = Guid.NewGuid().ToString();
        var customer = new Customer(customerId, "Customer1");
        var address = new Address("Street", "123", "123456789", "NY");
        var newAdress = new Address("Rua", "321", "4984", "Miami");
        customer.setAddress(address);


        var act = async () =>
        {
            using (var context = new DatabaseContext(options))
            {
                var repository = new CustomerRepository(context);
                await repository.CreateAsync(customer);

                var c = await repository.GetFindAsync(Guid.NewGuid().ToString());
            }
        };

        var exception = await Assert.ThrowsExceptionAsync<InvalidExpressionException>(act);
        Assert.AreEqual("Customer doesn't exist in the database", exception.Message);
    }

}