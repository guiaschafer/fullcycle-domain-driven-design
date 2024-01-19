using System.Data;
using FullCycle.DomainDrivenDesign.Domain.Checkout.Entity;
using FullCycle.DomainDrivenDesign.Domain.Checkout.Repository;
using FullCycle.DomainDrivenDesign.Infra.Shared.Database.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullCycle.DomainDrivenDesign.Infra.Checkout.Repository.EntityFrameworkCore;

public class OrderRepository : IOrderRepository
{
    private DatabaseContext _context;

    public OrderRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Order entity)
    {
        await _context.Orders.AddAsync(TransformEntityToModelDatabase(entity));
        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<Order>> GetAll()
    {
        var products = await _context.Orders.ToListAsync();
        return products.Select(TransformModelDatabaseToEntity);
    }

    public async Task<Order> GetFindAsync(string id)
    {
        var guidId = Guid.Parse(id);
        var order = await _context.Orders.FirstOrDefaultAsync(p => p.Id == guidId);

        if (order == null)
            return null;

        return TransformModelDatabaseToEntity(order);
    }

    public async Task UpdateAsync(Order entity)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(order => order.Id.ToString() == entity.Id);

        if (order == null)
            throw new InvalidExpressionException("Order doesn't exist in the database");

        order.OrderItems = entity.Itens.Select(item => TransformItemEntityToModel(entity, item)).ToList();

        _context.Orders.Update(order);
        _context.SaveChanges();
        return;
    }

    private static OrderModel TransformEntityToModelDatabase(Order entity)
    {
        return new OrderModel
        {
            Id = Guid.Parse(entity.Id),
            CustomerId = Guid.Parse(entity.CustomerId),
            Total = entity.Total,
            OrderItems = entity.Itens.Select(item => TransformItemEntityToModel(entity, item)).ToList()
        };
    }

    private static OrderItemModel TransformItemEntityToModel(Order entity, OrderItem item)
    {
        return new OrderItemModel
        {
            Id = Guid.Parse(item.Id),
            Name = item.Name,
            Price = item.Price,
            ProductId = Guid.Parse(item.ProductId),
            OrderId = Guid.Parse(entity.Id),
            Quantity = item.Quantity
        };
    }

    private Order TransformModelDatabaseToEntity(OrderModel model)
    {
        return new Order(model.Id.ToString(),
            model.CustomerId.ToString(),
            model.OrderItems.Select(item => new OrderItem(item.Id.ToString(), item.Name, item.Price, item.ProductId.ToString(), item.Quantity)).ToArray());
    }
}