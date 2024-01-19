namespace FullCycle.DomainDrivenDesign.Domain.Event.Shared;

public interface IEventHandler<T> where T : IEvent
{
    public void Handle(T evento);
}