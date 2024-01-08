

namespace FullCycle.DomainDrivenDesign.Domain.Entity;

public class Product
{
    private int Id;
    private string Name;
    private double Price;

    public Product(int id, string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;
        Validate();
    }

    private void Validate()
    {
        if (this.Id <= 0)
            throw new ArgumentNullException("Id is required");
        if (String.IsNullOrEmpty(this.Name))
            throw new ArgumentNullException("Name is required");
        if(this.Price <= 0)
            throw new ArgumentException("Price is required bigger than zero.");
    }

    public void changeName(string newName){
        this.Name = newName;
        Validate();
    }

    public void changePrice(double newPrice){
        this.Price = newPrice;
        Validate();
    }
}