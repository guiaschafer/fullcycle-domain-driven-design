using FullCycle.DomainDrivenDesign.Domain.Products.Entity;

namespace FullCycle.DomainDrivenDesign.Domain.Products.Service;

public class ProductService
{
    public static void IncreasePrice(Product[] products, int percentual)
    {
        foreach (var product in products)
        {
            product.changePrice(product.Price * (1 + (percentual / 100)));
        }
    }
}