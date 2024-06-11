using Application.Model.Output;
using Domain.Enum;
using MediatR;

namespace Application.Command;

public record PaymentCommand(decimal Value, Method Method, Guid UserId) : IRequest<Response>;


