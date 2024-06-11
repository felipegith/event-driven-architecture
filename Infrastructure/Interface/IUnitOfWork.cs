namespace Infrastructure.Interface;

public interface IUnitOfWork
{
    Task<bool> Commit();
}