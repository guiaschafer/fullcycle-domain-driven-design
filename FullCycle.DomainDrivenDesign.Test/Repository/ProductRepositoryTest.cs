using FullCycle.DomainDrivenDesign.Domain.Products.Entity;
using FullCycle.DomainDrivenDesign.Infra.Products.Repository.EntityFrameworkCore;
using FullCycle.DomainDrivenDesign.Infra.Shared.Database.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullCycle.DomainDrivenDesign.Test.Repository;

[TestClass]
public class ProductRepositoryTest
{
    private static DbContextOptions<DatabaseContext> options;
    public ProductRepositoryTest()
    {
        options = new DbContextOptionsBuilder<DatabaseContext>()
                 .UseInMemoryDatabase("DatabaseInMemoryTest")
                 .Options;
    }

    [TestMethod]
    public async Task CreateProductInDb_ExecuteAsExpected()
    {
        var productId = Guid.NewGuid().ToString();
        var product = new Product(productId, "Product 1", 10);
        Product productExpected;
        using (var context = new DatabaseContext(options))
        {
            var repository = new ProductRepository(context);
            await repository.CreateAsync(product);

            productExpected = await repository.GetFindAsync(productId);
        }

        Assert.IsTrue(product.Equals(productExpected));
    }

    [TestMethod]
    public async Task UpdateProductInDb_ExecuteAsExpected()
    {
        var productId = Guid.NewGuid().ToString();
        var product = new Product(productId, "Product 1", 10);
        Product productExpected;
        using (var context = new DatabaseContext(options))
        {
            var repository = new ProductRepository(context);
            await repository.CreateAsync(product);


            var productSaved = await repository.GetFindAsync(productId);
            productSaved.changeName("Product 2");
            productSaved.changePrice(20);

            await repository.UpdateAsync(productSaved);

            productExpected = await repository.GetFindAsync(productId);
        }

        Assert.AreEqual("Product 2", productExpected.Name);
        Assert.AreEqual(20, productExpected.Price);
    }

    [TestMethod]
    public async Task FindProductInDb_ExecuteAsExpected()
    {
        var productId = Guid.NewGuid().ToString();
        var product = new Product(productId, "Product 1", 10);
        Product productExpected;
        using (var context = new DatabaseContext(options))
        {
            var repository = new ProductRepository(context);
            await repository.CreateAsync(product);

            productExpected = await repository.GetFindAsync(productId);
        }

        Assert.AreEqual(productId, productExpected.Id);
    }

    [TestMethod]
    public async Task GetAllProducts_ExecuteAsExpected()
    {
        IEnumerable<Product> productExpected;
        using (var context = new DatabaseContext(options))
        {
            var product1 = new Product(Guid.NewGuid().ToString(), "Product 1", 10);
            var product2 = new Product(Guid.NewGuid().ToString(), "Product 2", 10);
            var repository = new ProductRepository(context);
            await repository.CreateAsync(product1);
            await repository.CreateAsync(product2);

            productExpected = await repository.GetAll(); ;
        }

        Assert.AreEqual(2, productExpected.Count());
    }
}