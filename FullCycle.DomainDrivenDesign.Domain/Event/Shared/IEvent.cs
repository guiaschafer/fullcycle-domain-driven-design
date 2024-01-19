namespace FullCycle.DomainDrivenDesign.Domain.Event.Shared;

public interface IEvent
{
    public DateTime DataTimeOcurred {get; }
    public Object EventData {get;}

}