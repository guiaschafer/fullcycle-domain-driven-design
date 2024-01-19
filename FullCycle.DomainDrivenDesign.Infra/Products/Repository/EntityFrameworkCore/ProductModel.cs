using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FullCycle.DomainDrivenDesign.Infra.Products.Repository.EntityFrameworkCore;

[Table("Product")]
[PrimaryKey(nameof(Id))]
public class ProductModel
{
    [Column("Id")]
    public Guid Id { get; set; }

    [Column("Name")]
    public string Name { get; set; }

    [Column("Price")]
    public double Price { get; set; }
}