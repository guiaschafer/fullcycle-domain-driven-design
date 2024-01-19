namespace FullCycle.DomainDrivenDesign.Domain.Event.Shared;

public interface IEventDispatcher
{
    void Notify(IEvent eventToNotify);
    void Register<T>(string eventName, IEventHandler<T> eventHandler) where T : IEvent;
    void Unregister<T>(string eventName, IEventHandler<T> eventHandler) where T : IEvent;
    void UnregisterAll();
}