using Application.Model.Output;
using MediatR;

namespace Application.Command.User;

public record RegisterUserCommand(string Name, string Email) : IRequest<Response>;
