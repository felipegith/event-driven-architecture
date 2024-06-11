using Infrastructure.Context;
using Infrastructure.Interceptor;
using Infrastructure.Interface;
using Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependency;

public static class Injection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Database>(opt =>
            opt.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 3))));

        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<PublishDomainEventsInterceptor>();
        services.AddMassTransit(config =>
        {
            config.UsingRabbitMq((context, configuration) =>
            {
                configuration.Host("localhost", "/", h =>
                {
                    
                    h.Username("guest");
                    h.Password("guest");
                });
            });
        });
        
        //services.AddExceptionHandler<GlobalExceptionHandle>();
        return services;
    }
}