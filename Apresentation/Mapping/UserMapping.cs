using Application.Command.User;
using Application.Model.Inputmodel;
using Mapster;

namespace Apresentation.Mapping;

public class UserMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateRegisterInputModel, RegisterUserCommand>();
    }
}