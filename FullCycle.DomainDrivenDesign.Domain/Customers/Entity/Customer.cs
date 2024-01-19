

using FullCycle.DomainDrivenDesign.Domain.Customers.ValueObject;

namespace FullCycle.DomainDrivenDesign.Domain.Customers.Entity;

public class Customer
{
    public string Id { private set; get; }
    public string Name { private set; get; }
    public bool Active { private set; get; }
    public int RewardsPoints { private set; get; }
    public Address? Address { private set; get; }

    public Customer(string id, string name)
    {
        Id = id;
        Name = name;

        Validate();
    }

    private void Validate()
    {
        if (String.IsNullOrEmpty(this.Id))
            throw new ArgumentNullException($"Id is required");
        if (String.IsNullOrEmpty(this.Name))
            throw new ArgumentNullException($"Name is required");
    }

    public void changeName(string name)
    {
        if (String.IsNullOrEmpty(name))
            throw new ArgumentNullException($"Name is required");

        Name = name;
    }

    public void activate()
    {
        if (Address == null)
            throw new ArgumentNullException($"Address is mandatory to activate a customer");

        Active = true;
    }

    public void deactivate() => Active = false;

    public void setAddress(Address address) => Address = address;

    public bool isActive() => this.Active;

    public void addRewardsPoits(int points) => this.RewardsPoints += points;

    // override object.Equals
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var customerType = (Customer)obj;

        if(customerType.Id != this.Id)
            return false;
        
        if(customerType.Name != this.Name)
            return false;

        if(!customerType.Address.Equals(this.Address))
            return false;

        return true;
    }


}