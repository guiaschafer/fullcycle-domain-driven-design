using FullCycle.DomainDrivenDesign.Domain.Entity;
using FullCycle.DomainDrivenDesign.Domain.Service;

namespace FullCycle.DomainDrivenDesign.Test.Service;

[TestClass]
public class ProductServiceTest
{
    [TestMethod]
    public void ChangePriceAllProducts()
    {
        var product1 = new Product(1, "product1", 10);
        var product2 = new Product(2, "product2", 20);
        var product3 = new Product(3, "product3", 30);

        var products = new Product[] { product1, product2, product3 };

        ProductService.IncreasePrice(products, 100);

        Assert.AreEqual(20, product1.Price);
        Assert.AreEqual(40, product2.Price);
        Assert.AreEqual(60, product3.Price);
    }
}