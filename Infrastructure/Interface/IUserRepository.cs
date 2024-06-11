using Domain;

namespace Infrastructure.Interface;

public interface IUserRepository
{
    void Create(User user, CancellationToken cancellationToken);
}