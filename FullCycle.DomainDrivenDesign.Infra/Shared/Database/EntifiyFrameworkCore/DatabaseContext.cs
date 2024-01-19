
using FullCycle.DomainDrivenDesign.Infra.Checkout.Repository.EntityFrameworkCore;
using FullCycle.DomainDrivenDesign.Infra.Customers.Repository.EntityFrameworkCore;
using FullCycle.DomainDrivenDesign.Infra.Products.Repository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace FullCycle.DomainDrivenDesign.Infra.Shared.Database.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<OrderModel> Orders { get; set; }
    public DbSet<OrderItemModel> OrderItems { get; set; }
    public DbSet<CustomerModel> Customers { get; set; }
    // public DbSet<Order> Orders {get;set;}
    // public 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");
    }
}