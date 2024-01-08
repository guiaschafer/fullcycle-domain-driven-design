
namespace FullCycle.DomainDrivenDesign.Domain.Entity;

public class Customer
{
    private int _id;
    private string _name;
    private bool _active;
    private Address? _address;

    public Customer(int id, string name)
    {
        _id = id;
        _name = name;

        Validate();
    }
    private void Validate()
    {
        if (this._id <= 0)
            throw new ArgumentNullException($"Id is required");
        if (String.IsNullOrEmpty(this._name))
            throw new ArgumentNullException($"Name is required");
    }

    public void changeName(string name)
    {
        if (String.IsNullOrEmpty(name))
            throw new ArgumentNullException($"Name is required");

        _name = name;
    }

    public void activate()
    {
        if (_address == null)
            throw new ArgumentNullException($"Address is mandatory to activate a customer");

        _active = true;
    }

    public void deactivate() => _active = false;

    public void setAddress(Address address) => _address = address;

    public bool isActive() => this._active;
}