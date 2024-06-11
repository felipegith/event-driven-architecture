using Domain.Enum;
using Events.Payment;

namespace Domain;

public class Payment : Entity
{
    public static Payment Create(decimal value, Method method, Guid userId)
    {
        var payment = new Payment()
        {
            Value = value,
            Method = method,
            UserId = userId
        };
        payment.AddDomainEvent(new PaymentCreatedIntegrationEvent(Guid.NewGuid(), payment.Id, payment.Value, "felipe@mail.com"));
        return payment;
    }

    public Payment(){}
    
    public Payment(decimal value, Method method, Guid userId)
    {
        Value = value;
        Method = method;
        UserId = userId;
    }
    public Guid Id { get; private set; } = Guid.NewGuid();
    public decimal Value { get; private set; }
    public Method Method { get; private set; }
    public Guid UserId { get; private set; }
    
    
}