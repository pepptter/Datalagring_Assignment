using LibraryApp.Infrastructure.Contexts;
using LibraryApp.Infrastructure.Entities;
using LibraryApp.Infrastructure.Interfaces;
using LibraryApp.Infrastructure.Repositories;
using LibraryApp.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryApp.Infrastructure.Repositories;

public interface IUserRepository : IRepo<UserEntity>
{

}

public class UserRepository(LibraryContext context, ILogger logger) : Repo<UserEntity, LibraryContext>(context, logger), IUserRepository
{
    private readonly LibraryContext _context = context;
    private readonly ILogger _logger = logger;

    public override async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        try
        {
            var entities = await _context.Users.ToListAsync();
            if (entities.Count != 0)
            {
                return entities;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(ex.Message, "Repo.GetAllAsync()", Shared.Utils.LogTypes.Error);
        }
        return null!;
    }

    public override Task<UserEntity> GetByIdAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        return base.GetByIdAsync(predicate);
    }
}
