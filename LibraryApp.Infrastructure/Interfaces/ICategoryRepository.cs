using LibraryApp.Infrastructure.Entities;

namespace LibraryApp.Infrastructure.Interfaces;

public interface ICategoryRepository : IRepo<CategoryEntity>
{
    /// <summary>
    /// Adds a new category to the repository.
    /// </summary>
    /// <param name="category">The category to add.</param>
    /// <returns>The added category entity.</returns>
    Task<CategoryEntity> AddCategoryAsync(CategoryEntity category);

    /// <summary>
    /// Retrieves a category by its ID from the repository.
    /// </summary>
    /// <param name="categoryId">The ID of the category to retrieve.</param>
    /// <returns>The category entity with the specified ID, or null if not found.</returns>
    Task<CategoryEntity?> GetCategoryByIdAsync(int categoryId);

    /// <summary>
    /// Retrieves a category by its name from the repository.
    /// </summary>
    /// <param name="categoryName">The name of the category to retrieve.</param>
    /// <returns>The category entity with the specified name, or null if not found.</returns>
    Task<CategoryEntity?> GetCategoryByNameAsync(string categoryName);

    /// <summary>
    /// Retrieves all books belonging to a category from the repository.
    /// </summary>
    /// <param name="categoryId">The ID of the category.</param>
    /// <returns>A collection of books belonging to the specified category.</returns>
    Task<IEnumerable<BookEntity>> GetBooksByCategoryAsync(int categoryId);

    /// <summary>
    /// Updates an existing category in the repository.
    /// </summary>
    /// <param name="category">The updated category entity.</param>
    /// <returns>The updated category entity.</returns>
    Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category);

    /// <summary>
    /// Removes a category from the repository by its ID.
    /// </summary>
    /// <param name="categoryId">The ID of the category to remove.</param>
    /// <returns>True if the category was successfully removed, otherwise false.</returns>
    Task<bool> RemoveCategoryAsync(int categoryId);

    /// <summary>
    /// Removes a category from the repository by its name.
    /// </summary>
    /// <param name="categoryName">The name of the category to remove.</param>
    /// <returns>True if the category was successfully removed, otherwise false.</returns>
    Task<bool> RemoveCategoryAsync(string categoryName);

    /// <summary>
    /// Removes a book from a category in the repository.
    /// </summary>
    /// <param name="bookId">The ID of the book to remove.</param>
    /// <param name="categoryId">The ID of the category to remove the book from.</param>
    /// <returns>True if the book was successfully removed from the category, otherwise false.</returns>
    Task<bool> RemoveBookFromCategoryAsync(int bookId, int categoryId);
}
