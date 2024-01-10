using FullCycle.DomainDrivenDesign.Domain.Entity;

namespace FullCycle.DomainDrivenDesign.Domain.Service;

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