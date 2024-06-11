using Events.Interface;

namespace Events.Payment;

public sealed record PaymentCreatedIntegrationEvent(Guid Id, Guid PaymentId, decimal Value, string BuyerEmail) : IEvent;