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
    public async Task<UserEntity> AddUserAsync(UserEntity user)
    {
        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "UserRepository.AddUserAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return null!;
        }
    }
    public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
    {
        try
        {
            return await _context.Users.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "UserRepository.GetAllUsersAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return Enumerable.Empty<UserEntity>();
        }
    }

    public async Task<UserEntity?> GetUserByIdAsync(int userId)
    {
        try
        {
            return await _context.Users.FindAsync(userId);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "UserRepository.GetUserByIdAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return null!;
        }
    }
    public async Task<UserEntity?> GetUserByUserEmailAsync(string userEmail)
    {
        try
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "UserRepository.GetUserByUsernameAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return null!;
        }
    }
    public async Task<UserEntity> UpdateUserAsync(UserEntity user)
    {
        try
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "UserRepository.UpdateUserAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return null!;
        }
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        try
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "UserRepository.DeleteUserAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return false;
        }
    }
}
