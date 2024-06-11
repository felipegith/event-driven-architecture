using Application.Command;
using Application.Model.Inputmodel;
using Mapster;

namespace Apresentation.Mapping;

public class PaymentMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreatePaymentInputModel, PaymentCommand>();
    }
}