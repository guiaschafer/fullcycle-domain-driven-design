namespace FullCycle.DomainDrivenDesign.Domain.Products.Entity;

public interface IProduct
{
    string Id { get; }
    string Name { get; }
    double Price { get; }
}