using FullCycle.DomainDrivenDesign.Domain.Products.Event;
using FullCycle.DomainDrivenDesign.Domain.Products.Event.Dto;
using FullCycle.DomainDrivenDesign.Domain.Products.Event.Handler;
using FullCycle.DomainDrivenDesign.Domain.Shared.Event;
using Moq;

namespace FullCycle.DomainDrivenDesign.Test.Event.Shared;

[TestClass]
public class EventDispatcherTest
{

    [TestMethod]
    public void RegisterEventHandler_ExecuteAsExpected()
    {
        var eventDispatcher = new EventDispatcher();
        var eventHandler = new SendEmailWhenProductIsCreatedHandler();

        eventDispatcher.Register("ProductCreatedEvent", eventHandler);

        Assert.IsTrue(eventDispatcher.eventHandlersList[typeof(ProductCreatedEvent)] != null);
        Assert.AreEqual(1, eventDispatcher.eventHandlersList[typeof(ProductCreatedEvent)].Count());
    }

    [TestMethod]
    public void UnRegisterEventHandler_ExecuteAsExpected()
    {
        var eventDispatcher = new EventDispatcher();
        var eventHandler = new SendEmailWhenProductIsCreatedHandler();

        eventDispatcher.Register("ProductCreatedEvent", eventHandler);
        Assert.AreEqual(1, eventDispatcher.eventHandlersList[typeof(ProductCreatedEvent)].Count());

        eventDispatcher.Unregister("ProductCreatedEvent", eventHandler);
        Assert.AreEqual(0, eventDispatcher.eventHandlersList[typeof(ProductCreatedEvent)].Count());
    }

    [TestMethod]
    public void UnRegisterAll_ExecuteAsExpected()
    {
        var eventDispatcher = new EventDispatcher();
        var eventHandler = new SendEmailWhenProductIsCreatedHandler();

        eventDispatcher.Register("ProductCreatedEvent", eventHandler);
        Assert.AreEqual(1, eventDispatcher.eventHandlersList[typeof(ProductCreatedEvent)].Count());

        eventDispatcher.UnregisterAll();
        Assert.AreEqual(0, eventDispatcher.eventHandlersList.Count);
    }

    [TestMethod]
    public void Notify_ExecuteAsExpected()
    {
        var eventDispatcher = new EventDispatcher();
        var eventHandler = new Mock<SendEmailWhenProductIsCreatedHandler>();

        eventDispatcher.Register("ProductCreatedEvent", eventHandler.Object);
        Assert.AreEqual(1, eventDispatcher.eventHandlersList[typeof(ProductCreatedEvent)].Count());


        var productEventDto = new ProductEventDto()
        {
            Name = "Product 1",
            Description = "Product 1 Desc",
            Price = 10.0m,
        };

        eventDispatcher.Notify(new ProductCreatedEvent(productEventDto));

        eventHandler.Verify(h => h.Handle(It.IsAny<ProductCreatedEvent>()),Times.Once());
    }

}