using LibraryApp.Business.Dtos;

namespace LibraryApp.Business.Interfaces;

public interface ICategoryService
{
    /// <summary>
    /// Retrieves all categories from the library.
    /// </summary>
    /// <returns>A collection of all categories.</returns>
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();

    /// <summary>
    /// Adds a new category to the library.
    /// </summary>
    /// <param name="category">The category as an object, either categoryDto or string categoryName.</param>
    /// <returns>The added category.</returns>
    Task<CategoryDto> AddCategoryAsync(object category);

    /// <summary>
    /// Updates an existing category in the library.
    /// </summary>
    /// <param name="categoryDto">The updated category data.</param>
    /// <returns>The updated category, or null if the category with the specified ID is not found.</returns>
    Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto);

    /// <summary>
    /// Removes a category from the library.
    /// </summary>
    /// <param name="categoryId">The ID of the category to be removed.</param>
    /// <returns>True if the category was successfully removed, otherwise false.</returns>
    Task<bool> RemoveCategoryAsync(int categoryId);

    /// <summary>
    /// Retrieves a category by its name asynchronously.
    /// </summary>
    /// <param name="categoryName">The name of the category to retrieve.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains the category DTO if found; otherwise, it returns null.</returns>
    Task<CategoryDto> GetCategoryByNameAsync(string categoryName);
}
