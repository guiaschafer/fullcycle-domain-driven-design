using FullCycle.DomainDrivenDesign.Domain.Entity;

namespace FullCycle.DomainDrivenDesign.Test.Entity;

[TestClass]
public class CustomerTest
{
    [TestMethod]
    public void ValidateCreateCustomerShouldThrowErrorWhenIdIsEmpty()
    {
        var act = () => new Customer(0, "Teste");
        Assert.ThrowsException<ArgumentNullException>(act);
    }

    [TestMethod]
    public void ValidateCreateCustomerShouldThrowErrorWhenNameIsEmptyOrNull()
    {
        var act = () => new Customer(1, "");
        Assert.ThrowsException<ArgumentNullException>(act);
    }

    [TestMethod]
    public void ValidateChangeShouldThrowErrorWhenNameIsEmptyOrNull()
    {
        var customer = new Customer(1, "Name");
        var act = () => customer.changeName("");
        Assert.ThrowsException<ArgumentNullException>(act);
    }

    [TestMethod]
    public void ActivateCustomerShouldActivateCorrectly()
    {
        var customer = new Customer(1, "Name");
        var address = new Address("Rua", "Número", "zip", "city");

        customer.setAddress(address);
        customer.activate();

        Assert.IsTrue(customer.isActive());
    }


    [TestMethod]
    public void ActivateCustomerWithoutAddressShouldThrowError()
    {
        var customer = new Customer(1, "Name");
        var act = () => customer.activate();

        Assert.ThrowsException<ArgumentNullException>(act);
    }


    [TestMethod]
    public void DeactivateCustomerShouldDeactivateCorrectly()
    {
        var customer = new Customer(1, "Name");
        var address = new Address("Rua", "Número", "zip", "city");

        customer.setAddress(address);
        customer.activate();
        customer.deactivate();

        Assert.IsFalse(customer.isActive());
    }
}


