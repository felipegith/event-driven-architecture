using Domain;
using Infrastructure.Context;
using Infrastructure.Interface;

namespace Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly Database _context;

    public PaymentRepository(Database context)
    {
        _context = context;
    }

    public async Task<Payment> CreateAsync(Payment payment, CancellationToken cancellationToken)
    {
        try
        {
            await _context.Payments.AddAsync(payment);
            return payment;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}