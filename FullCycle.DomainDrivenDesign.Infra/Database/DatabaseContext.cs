using FullCycle.DomainDrivenDesign.Infra.Database.Model;
using Microsoft.EntityFrameworkCore;
namespace FullCycle.DomainDrivenDesign.Infra.Database;

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