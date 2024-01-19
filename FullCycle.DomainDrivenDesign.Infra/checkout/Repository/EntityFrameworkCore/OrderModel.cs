using System.ComponentModel.DataAnnotations.Schema;
using FullCycle.DomainDrivenDesign.Infra.Customers.Repository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullCycle.DomainDrivenDesign.Infra.Checkout.Repository.EntityFrameworkCore;

[Table("Order")]
[PrimaryKey(nameof(Id))]
public class OrderModel
{
    [Column("Id")]
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public virtual CustomerModel Customer { get; set; }

    [Column("Total")]
    public decimal Total { get; set; }

 
    public ICollection<OrderItemModel> OrderItems { get; set; }
}