namespace FullCycle.DomainDrivenDesign.Domain.Shared.Event;

public class EventDispatcher : IEventDispatcher
{
    public Dictionary<Type, ICollection<Delegate>> eventHandlersList { private set; get; }

    public EventDispatcher()
    {
        eventHandlersList = new Dictionary<Type, ICollection<Delegate>>();
    }

    public void Notify(IEvent eventToNotify)
    {
        var eventType = eventToNotify.GetType();
        ICollection<Delegate> listOfHandlers;
        if (eventHandlersList.ContainsKey(eventType))
        {
            foreach (var listener in eventHandlersList[eventType].ToList())
            {
                ((Action<IEvent>)listener)(eventToNotify);
            }
        }
    }

    public void Register<T>(string eventName, IEventHandler<T> eventHandler) where T : IEvent
    {
        var handlerType = eventHandler.GetType();
        var eventTypes = GetEventTypes(handlerType);

        foreach (var eventType in eventTypes)
        {
            if (!eventHandlersList.ContainsKey(eventType))
            {
                this.eventHandlersList[eventType] = new List<Delegate>();
            }

            var handler = CreateEventHandlerDelegate(eventHandler, eventType);
            this.eventHandlersList[eventType].Add(handler);
        }
    }


    public void Unregister<T>(string eventName, IEventHandler<T> eventHandler) where T : IEvent
    {
        var handlerType = eventHandler.GetType();
        var eventTypes = GetEventTypes(handlerType);

        foreach (var eventType in eventTypes)
        {
            if (eventHandlersList.ContainsKey(eventType))
            {
                var handler = CreateEventHandlerDelegate(eventHandler, eventType);
                this.eventHandlersList[eventType].Remove(handler);
            }
        }
    }

    public void UnregisterAll()
    {
        eventHandlersList = new Dictionary<Type, ICollection<Delegate>>();
    }

    private Delegate CreateEventHandlerDelegate(object eventHandler, Type eventType)
    {
        var handleEventMethod = typeof(IEventHandler<>).MakeGenericType(eventType)
            .GetMethod("Handle");

        return Delegate.CreateDelegate(typeof(Action<>).MakeGenericType(eventType), eventHandler, handleEventMethod);
    }
    private IEnumerable<Type> GetEventTypes(Type eventSubscriberType)
    {
        var eventSubscriberInterface = typeof(IEventHandler<>);
        return eventSubscriberType.GetInterfaces()
            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == eventSubscriberInterface)
            .Select(i => i.GetGenericArguments()[0]);
    }
}