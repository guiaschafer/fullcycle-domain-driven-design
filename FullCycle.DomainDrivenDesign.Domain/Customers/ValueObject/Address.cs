namespace FullCycle.DomainDrivenDesign.Domain.Customers.ValueObject;

public struct Address
{
    public string Street { private set; get; }
    public string Number { private set; get; }
    public string Zip { private set; get; }
    public string City { private set; get; }
    public Address(string street, string number, string zip, string city)
    {
        Street = street;
        Number = number;
        Zip = zip;
        City = city;

        Validate();
    }

    private void Validate()
    {
        if(String.IsNullOrEmpty(this.Street))
            throw new ArgumentNullException($"{nameof(this.Street)} is required");
        if(String.IsNullOrEmpty(this.Number))
            throw new ArgumentNullException($"{nameof(this.Number)} is required");
        if(String.IsNullOrEmpty(this.Zip))
            throw new ArgumentNullException($"{nameof(this.Zip)} is required");
        if(String.IsNullOrEmpty(this.City))
            throw new ArgumentNullException($"{nameof(this.City)} is required");
    }
}