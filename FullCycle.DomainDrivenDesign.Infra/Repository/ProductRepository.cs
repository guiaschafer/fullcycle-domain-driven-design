using System.Data;
using FullCycle.DomainDrivenDesign.Domain.Entity;
using FullCycle.DomainDrivenDesign.Domain.Repository;
using FullCycle.DomainDrivenDesign.Infra.Database;
using FullCycle.DomainDrivenDesign.Infra.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace FullCycle.DomainDrivenDesign.Infra.Repository;

public class ProductRepository : IProductRepository
{
    private DatabaseContext _context;

    public ProductRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Product entity)
    {
        await _context.Products.AddAsync(TransformEntityToModelDatabase(entity));
        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<Product>> GetAll()
    {
        var products = await _context.Products.ToListAsync();
        return products.Select(TransformModelDatabaseToEntity);
    }

    public async Task<Product> GetFindAsync(string id)
    {
        var guidId = Guid.Parse(id);
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == guidId);

        if (product == null)
            return null;

        return TransformModelDatabaseToEntity(product);
    }

    public async Task UpdateAsync(Product entity)
    {
        var product = await _context.Products.FirstOrDefaultAsync(product => product.Id.ToString() == entity.Id);

        if(product == null)
            throw new InvalidExpressionException("Product doesn't exist in the database");

        product.Name = entity.Name;
        product.Price  = entity.Price;

        _context.Products.Update(product);
        _context.SaveChanges();
    }

    private static ProductModel TransformEntityToModelDatabase(Product entity)
    {
        return new ProductModel
        {
            Id = Guid.Parse(entity.Id),
            Name = entity.Name,
            Price = entity.Price
        };
    }   

    private Product TransformModelDatabaseToEntity(ProductModel product)
    {
        return new Product(product.Id.ToString(), product.Name, product.Price);
    }
}