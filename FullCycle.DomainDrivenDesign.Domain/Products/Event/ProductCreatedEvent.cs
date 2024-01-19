
using FullCycle.DomainDrivenDesign.Domain.Shared.Event;

namespace FullCycle.DomainDrivenDesign.Domain.Products.Event;

public class ProductCreatedEvent : IEvent
{
    public DateTime DataTimeOcurred {private set; get;}
    public object EventData { private set; get;}

    public ProductCreatedEvent(object eventData)
    {
        this.DataTimeOcurred = DateTime.Now;
        this.EventData = eventData;
    }
}