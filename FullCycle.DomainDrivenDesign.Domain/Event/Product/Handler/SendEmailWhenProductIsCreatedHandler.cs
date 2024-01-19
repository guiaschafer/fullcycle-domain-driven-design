using FullCycle.DomainDrivenDesign.Domain.Event.Shared;

namespace FullCycle.DomainDrivenDesign.Domain.Event.Handler;

public class SendEmailWhenProductIsCreatedHandler : IEventHandler<ProductCreatedEvent>
{
    public void Handle(ProductCreatedEvent evento)
    {
        Console.Write("Sending email to ...");
    }
}