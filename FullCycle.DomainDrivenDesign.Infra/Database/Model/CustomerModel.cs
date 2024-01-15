using System.ComponentModel.DataAnnotations.Schema;
using FullCycle.DomainDrivenDesign.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FullCycle.DomainDrivenDesign.Infra.Database.Model;

[Table("Customer")]
[PrimaryKey(nameof(Id))]
public class CustomerModel
{
    [Column("Id")]
    public Guid Id { get; set; }

    [Column("Name")]
    public string Name { get; set; }

    [Column("Active")]
    public bool Active { get; set; }

    [Column("RewardsPoints")]
    public int RewardsPoints { get; set; }



    [Column("Street")]
    public string Street { get; set; }
    [Column("Number")]
    public string Number { get; set; }
    [Column("Zip")]
    public string Zip { get; set; }
    [Column("City")]
    public string City { get; set; }
}