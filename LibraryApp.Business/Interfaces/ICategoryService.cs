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
    /// <param name="categoryDto">The category data to be added.</param>
    /// <returns>The added category.</returns>
    Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto);

    /// <summary>
    /// Updates an existing category in the library.
    /// </summary>
    /// <param name="categoryDto">The updated category data.</param>
    /// <returns>The updated category, or null if the category with the specified ID is not found.</returns>
    Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto);

    /// <summary>
    /// Retrieves all books belonging to a specific category.
    /// </summary>
    /// <param name="categoryId">The ID of the category.</param>
    /// <returns>A collection of books in the specified category.</returns>
    Task<IEnumerable<BookDto>> GetBooksByCategoryAsync(int categoryId);

    /// <summary>
    /// Removes a category from the library.
    /// </summary>
    /// <param name="categoryId">The ID of the category to be removed.</param>
    /// <returns>True if the category was successfully removed, otherwise false.</returns>
    Task<bool> RemoveCategoryAsync(int categoryId);
}
