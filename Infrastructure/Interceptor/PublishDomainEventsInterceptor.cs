using Domain.Interface;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Interceptor;

public class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly IPublisher _publish;
    private readonly IBus _bus;

    public PublishDomainEventsInterceptor(IPublisher publish, IBus bus)
    {
        _publish = publish;
        _bus = bus;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        await PublishDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private async Task PublishDomainEvents(DbContext? dbContext)
    {
        if (dbContext is null)
            return;
        
        var entityWithDomainEvent = dbContext.ChangeTracker.Entries<IHasDomainEvent>()
            .Where(entry => entry.Entity.DomainEvents.Any())
            .Select(entry => entry.Entity)
            .ToList();
        
        var domainEvents = entityWithDomainEvent.SelectMany(entry => entry.DomainEvents).ToList();
        
        entityWithDomainEvent.ForEach(entity => entity.ClearDomainEvents());
        
        foreach (var domainEvent in domainEvents)
        {
            await _bus.Publish(domainEvent);
        }
    }
}