using System.Net;
using Application.Model.Output;
using Domain;
using Infrastructure.Interface;
using MediatR;

namespace Application.Command;

public class PaymentCommandHandle : IRequestHandler<PaymentCommand, Response>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _uow;
    

    public PaymentCommandHandle(IPaymentRepository paymentRepository, IUnitOfWork uow)
    {
        _paymentRepository = paymentRepository;
        _uow = uow;
    }

    public async Task<Response> Handle(PaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = Payment.Create(request.Value, request.Method, request.UserId);
        
        var create = await _paymentRepository.CreateAsync(payment, cancellationToken);
        await _uow.Commit();
        
        return new Response(true, "Success", HttpStatusCode.Created, payment);
    }
}