namespace FullCycle.DomainDrivenDesign.Domain.Shared.Event;

public interface IEventHandler<T> where T : IEvent
{
    public void Handle(T evento);
}