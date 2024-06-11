using Events.Enum;
using Events.Interface;
using Type = Events.Enum.Type;

namespace Events.Payment;

public sealed record PaymentCreatedIntegrationEvent(Guid Id, Guid PaymentId, decimal Value, string BuyerEmail) : IEvent;