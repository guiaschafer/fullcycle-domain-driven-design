using FullCycle.DomainDrivenDesign.Domain.Products.Entity;
using FullCycle.DomainDrivenDesign.Domain.Products.Factory;

namespace FullCycle.DomainDrivenDesign.Test.Factory;

[TestClass]
public class ProductFactoryTest
{
    [TestMethod]
    public void CreateProduct_ExecuteAsExpected()
    {
        IProduct productByFactory = ProductFactory.Create("a", "Product A", 1);
        
        Assert.AreEqual(productByFactory.GetType(), typeof(Product));
        Assert.IsNotNull(productByFactory.Id);
        Assert.IsNotNull(productByFactory.Name);
        Assert.AreEqual(1,productByFactory.Price);
    }

     [TestMethod]
    public void CreateProductB_ExecuteAsExpected()
    {
        IProduct productByFactory = ProductFactory.Create("b", "Product B", 1);
        
        Assert.AreEqual(productByFactory.GetType(), typeof(ProductB));
        Assert.IsNotNull(productByFactory.Id);
        Assert.IsNotNull(productByFactory.Name);
        Assert.AreEqual(2,productByFactory.Price);
    }
}