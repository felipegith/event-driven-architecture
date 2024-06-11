using Domain.Enum;

namespace Application.Model.Inputmodel;

public record CreatePaymentInputModel(decimal Value, Method Method, Guid UserId);
