using FullCycle.DomainDrivenDesign.Domain.Products.Entity;

namespace FullCycle.DomainDrivenDesign.Domain.Products.Factory;

public class ProductFactory
{
    public static IProduct Create(string productToCreate, string name, double price)
    {
        IProduct product;
        switch (productToCreate)
        {
            case "a":
                product = new Product(Guid.NewGuid().ToString(), name, price);
                break;
            case "b":
                product = new ProductB(Guid.NewGuid().ToString(), name, price);
                break;
            default:
                product = new Product(Guid.NewGuid().ToString(), name, price);
                break;
        }


        return product;
    }
}