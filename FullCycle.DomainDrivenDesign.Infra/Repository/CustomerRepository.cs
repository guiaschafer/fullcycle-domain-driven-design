using System.Data;
using FullCycle.DomainDrivenDesign.Domain.Entity;
using FullCycle.DomainDrivenDesign.Domain.Repository;
using FullCycle.DomainDrivenDesign.Infra.Database;
using FullCycle.DomainDrivenDesign.Infra.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace FullCycle.DomainDrivenDesign.Infra.Repository;

public class CustomerRepository : ICustomerRepository
{
    private DatabaseContext _context;

    public CustomerRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Customer entity)
    {
        await _context.Customers.AddAsync(TransformEntityToModelDatabase(entity));
        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<Customer>> GetAll()
    {
        var products = await _context.Customers.ToListAsync();
        return products.Select(TransformModelDatabaseToEntity);
    }

    public async Task<Customer> GetFindAsync(string id)
    {
        var guidId = Guid.Parse(id);
        var customer = await _context.Customers.FirstOrDefaultAsync(p => p.Id == guidId);

        if (customer == null)
            throw new InvalidExpressionException("Customer doesn't exist in the database");

        return TransformModelDatabaseToEntity(customer);
    }

    public async Task UpdateAsync(Customer entity)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(product => product.Id.ToString() == entity.Id);

        if (customer == null)
            throw new InvalidExpressionException("Customer doesn't exist in the database");

        customer.Name = entity.Name;
        customer.RewardsPoints = entity.RewardsPoints;
        customer.Active = entity.isActive();
        customer.Street = entity.Address.Value.Street;
        customer.Number = entity.Address.Value.Number;
        customer.City = entity.Address.Value.City;
        customer.Zip = entity.Address.Value.Zip;


        _context.Customers.Update(customer);
        _context.SaveChanges();
    }

    private static CustomerModel TransformEntityToModelDatabase(Customer entity)
    {
        return new CustomerModel
        {
            Id = Guid.Parse(entity.Id),
            Name = entity.Name,
            Active = entity.isActive(),
            RewardsPoints = entity.RewardsPoints,
            City = entity.Address.Value.City,
            Number = entity.Address.Value.Number,
            Street = entity.Address.Value.Street,
            Zip = entity.Address.Value.Zip
        };
    }

    private Customer TransformModelDatabaseToEntity(CustomerModel customerModel)
    {
        var address = new Address(customerModel.Street, customerModel.Number, customerModel.Zip, customerModel.City);
        var customer = new Customer(customerModel.Id.ToString(), customerModel.Name);
        customer.addRewardsPoits(customerModel.RewardsPoints);
        customer.setAddress(address);
        return customer;
    }
}