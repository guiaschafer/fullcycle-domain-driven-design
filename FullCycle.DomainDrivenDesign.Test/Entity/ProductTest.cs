using FullCycle.DomainDrivenDesign.Domain.Entity;

namespace FullCycle.DomainDrivenDesign.Test.Entity;

[TestClass]
public class ProductTest
{
    [TestMethod]
    public void CreateProductWithoutIdShouldThrowError()
    {
        var actProduct = () => new Product(0, "Product 1", 100);
        Assert.ThrowsException<ArgumentNullException>(actProduct, "Id is required");
    }

    [TestMethod]
    public void CreateProductWithoutNameShouldThorwError()
    {
        var actProduct = () => new Product(1, "", 100);
        Assert.ThrowsException<ArgumentNullException>(actProduct, "Name is required");
    }

    [TestMethod]
    public void CreateProductWithoutPriceShouldThorwError()
    {
        var actProduct = () => new Product(1, "Product 1", -1);
        var excpetion = Assert.ThrowsException<ArgumentException>(actProduct);

        Assert.AreEqual("Price is required bigger than zero.", excpetion.Message);
    }
    
}