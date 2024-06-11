using Domain;
using Events.Interface;
using Infrastructure.Interceptor;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class Database : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;


    public Database(DbContextOptions<Database> options,
        PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    
    public DbSet<Payment> Payments { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<List<IEvent>>();
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}