namespace FullCycle.DomainDrivenDesign.Domain.Shared.Event;

public interface IEvent
{
    public DateTime DataTimeOcurred {get; }
    public Object EventData {get;}

}