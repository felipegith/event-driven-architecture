using Domain;
using Infrastructure.Context;
using Infrastructure.Interface;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly Database _context;

    public UserRepository(Database context)
    {
        _context = context;
    }

    public void Create(User user, CancellationToken cancellationToken)
    {
        try
        {
            _context.Users.Add(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}