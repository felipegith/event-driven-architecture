using Domain;

namespace Infrastructure.Interface;

public interface IPaymentRepository
{
    Task<Payment> CreateAsync(Payment payment, CancellationToken cancellationToken);
}