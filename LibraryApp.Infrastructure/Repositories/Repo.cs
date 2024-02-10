using LibraryApp.Infrastructure.Interfaces;
using LibraryApp.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace LibraryApp.Infrastructure.Repositories;

public abstract class Repo<TEntity, TContext> : IRepo<TEntity> where TEntity : class where TContext : DbContext
{
    private readonly TContext _context;
    private readonly ILogger _logger;

    protected Repo(TContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "Repo.CreateAsync()", Business.Utils.LogTypes.Error);
        }
        return null!;

    }
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        try
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            if (entities.Count != 0)
            {
                return entities;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "Repo.GetAllAsync()", Business.Utils.LogTypes.Error);
        }
        return null!;
    }
    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return entity!;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "Repo.GetByIdAsync()", Business.Utils.LogTypes.Error);
            return null!;
        }
    }
    public virtual async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity entity)
    {
        try
        {
            var entityToUpdate = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (entityToUpdate != null)
            {
                _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entityToUpdate;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "Repo.UpdateAsync()", Business.Utils.LogTypes.Error);
        }
        return null!;
    }
    public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entityToDelete = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (entityToDelete != null)
            {
                _context.Set<TEntity>().Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "Repo.DeleteAsync()", Business.Utils.LogTypes.Error);
        }
        return false;
    }
    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (entity != null)
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "Repo.ExistsAsync()", Business.Utils.LogTypes.Error);
        }
        return false;
    }
}
