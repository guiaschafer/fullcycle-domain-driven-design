using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FullCycle.DomainDrivenDesign.Infra.Database.Model;

[Table("OrderItem")]
[PrimaryKey(nameof(Id))]
public class OrderItemModel
{
    [Column("Id")]
    public Guid Id { get; set; }
    
    public Guid ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual ProductModel Product { get; set; }

    [Column("Name")]
    public string Name { get; set; }

    [Column("Price")]
    public decimal Price { get; set; }

    [Column("Quantity")]
    public int Quantity { get; set; }

    public Guid OrderId { get; set; }
    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public OrderModel Order { get; set; }
}