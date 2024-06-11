using Infrastructure.Context;
using Infrastructure.Interface;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly Database _context;

    public UnitOfWork(Database context)
    {
        _context = context;
    }
    public async Task<bool> Commit()
    {
        var success = (await _context.SaveChangesAsync()) > 0;

        return success;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}