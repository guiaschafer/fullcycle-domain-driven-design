
using FullCycle.DomainDrivenDesign.Domain.Shared.Event;

namespace FullCycle.DomainDrivenDesign.Domain.Products.Event.Handler;

public class SendEmailWhenProductIsCreatedHandler : IEventHandler<ProductCreatedEvent>
{
    public void Handle(ProductCreatedEvent evento)
    {
        Console.Write("Sending email to ...");
    }
}