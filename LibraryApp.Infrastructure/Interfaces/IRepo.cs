using LibraryApp.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Interfaces
{
    public interface IRepo<TEntity> where TEntity : class
    {
        /// <summary>
        /// Creates a new entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The created entity, or null if creation fails.</returns>
        Task<TEntity> CreateAsync(TEntity entity);

        /// <summary>
        /// Retrieves all entities from the repository.
        /// </summary>
        /// <returns>A collection of all entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Retrieves an entity by the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to filter entities.</param>
        /// <returns>The first entity matching the predicate, or null if not found.</returns>
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Updates an entity matching the specified predicate with the provided entity data.
        /// </summary>
        /// <param name="predicate">The predicate to filter entities.</param>
        /// <param name="entity">The entity data to update.</param>
        /// <returns>The updated entity, or null if update fails.</returns>
        Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity entity);

        /// <summary>
        /// Deletes an entity matching the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to filter entities.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Checks if an entity exists in the repository based on the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to filter entities.</param>
        /// <returns>True if an entity exists, otherwise false.</returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
