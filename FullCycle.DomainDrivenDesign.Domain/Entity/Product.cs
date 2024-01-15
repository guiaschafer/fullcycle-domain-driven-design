

namespace FullCycle.DomainDrivenDesign.Domain.Entity;

public class Product
{
    public string Id { private set; get; }
    public string Name { private set; get; }
    public double Price { private set; get; }

    public Product(string id, string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;
        Validate();
    }

    private void Validate()
    {
        if (String.IsNullOrEmpty(this.Id))
            throw new ArgumentNullException("Id is required");
        if (String.IsNullOrEmpty(this.Name))
            throw new ArgumentNullException("Name is required");
        if (this.Price <= 0)
            throw new ArgumentException("Price is required bigger than zero.");
    }

    public void changeName(string newName)
    {
        this.Name = newName;
        Validate();
    }

    public void changePrice(double newPrice)
    {
        this.Price = newPrice;
        Validate();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var productTyped = (Product)obj;
        if (productTyped.Id != this.Id)
            return false;

        if (productTyped.Name != this.Name)
            return false;

        if (productTyped.Price != this.Price)
            return false;

        return true;
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        throw new System.NotImplementedException();
        return base.GetHashCode();
    }
}