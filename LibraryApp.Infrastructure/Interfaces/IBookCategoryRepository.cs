using LibraryApp.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Interfaces;

public interface IBookCategoryRepository : IRepo<BookCategoryEntity>
{
    /// <summary>
    /// Adds a book to the specified category.
    /// </summary>
    /// <param name="bookId">The ID of the book to add.</param>
    /// <param name="categoryId">The ID of the category to add the book to.</param>
    Task AddBookToCategoryAsync(int bookId, int categoryId);

    /// <summary>
    /// Adds a book to the specified category.
    /// </summary>
    /// <param name="bookId">The ID of the book to add.</param>
    /// <param name="categoryName">The name of the category to add the book to.</param>
    Task AddBookToCategoryAsync(int bookId, string categoryName);

    /// <summary>
    /// Adds a book to the specified category.
    /// </summary>
    /// <param name="bookTitle">The title of the book to add.</param>
    /// <param name="categoryId">The ID of the category to add the book to.</param>
    Task AddBookToCategoryAsync(string bookTitle, int categoryId);

    /// <summary>
    /// Adds a book to the specified category.
    /// </summary>
    /// <param name="bookTitle">The title of the book to add.</param>
    /// <param name="categoryName">The name of the category to add the book to.</param>
    Task AddBookToCategoryAsync(string bookTitle, string categoryName);

    /// <summary>
    /// Deletes the association between a book and a category.
    /// </summary>
    /// <param name="bookId">The ID of the book.</param>
    /// <param name="categoryId">The ID of the category.</param>
    Task DeleteAsync(int bookId, int categoryId);

    /// <summary>
    /// Deletes the association between a book and a category.
    /// </summary>
    /// <param name="bookId">The ID of the book.</param>
    /// <param name="categoryName">The name of the category.</param>
    Task DeleteAsync(int bookId, string categoryName);

    /// <summary>
    /// Deletes the association between a book and a category.
    /// </summary>
    /// <param name="bookTitle">The title of the book.</param>
    /// <param name="categoryId">The ID of the category.</param>
    Task DeleteAsync(string bookTitle, int categoryId);

    /// <summary>
    /// Deletes the association between a book and a category.
    /// </summary>
    /// <param name="bookTitle">The title of the book.</param>
    /// <param name="categoryName">The name of the category.</param>
    Task DeleteAsync(string bookTitle, string categoryName);

    /// <summary>
    /// Retrieves all book-category associations from the repository.
    /// </summary>
    /// <returns>A collection of all book-category associations.</returns>
    new Task<IEnumerable<BookCategoryEntity>> GetAllAsync();

    /// <summary>
    /// Retrieves all books associated with the specified category.
    /// </summary>
    /// <param name="categoryId">The ID of the category.</param>
    /// <returns>A collection of books associated with the specified category.</returns>
    Task<IEnumerable<BookEntity>> GetBooksByCategoryAsync(int categoryId);

    /// <summary>
    /// Retrieves all books associated with the specified category.
    /// </summary>
    /// <param name="categoryName">The name of the category.</param>
    /// <returns>A collection of books associated with the specified category.</returns>
    Task<IEnumerable<BookEntity>> GetBooksByCategoryAsync(string categoryName);

    /// <summary>
    /// Retrieves all categories associated with the specified book.
    /// </summary>
    /// <param name="bookId">The ID of the book.</param>
    /// <returns>A collection of categories associated with the specified book.</returns>
    Task<IEnumerable<CategoryEntity?>> GetCategoriesByBookAsync(int bookId);

    /// <summary>
    /// Retrieves all categories associated with the specified book.
    /// </summary>
    /// <param name="bookTitle">The title of the book.</param>
    /// <returns>A collection of categories associated with the specified book.</returns>
    Task<IEnumerable<CategoryEntity?>> GetCategoriesByBookAsync(string bookTitle);

    /// <summary>
    /// Removes a book from the specified category.
    /// </summary>
    /// <param name="bookId">The ID of the book to remove.</param>
    /// <param name="categoryId">The ID of the category to remove the book from.</param>
    Task RemoveBookFromCategoryAsync(int bookId, int categoryId);

    /// <summary>
    /// Removes a book from the specified category.
    /// </summary>
    /// <param name="bookId">The ID of the book to remove.</param>
    /// <param name="categoryName">The name of the category to remove the book from.</param>
    Task RemoveBookFromCategoryAsync(int bookId, string categoryName);

    /// <summary>
    /// Removes a book from the specified category.
    /// </summary>
    /// <param name="bookTitle">The title of the book to remove.</param>
    /// <param name="categoryId">The ID of the category to remove the book from.</param>
    Task RemoveBookFromCategoryAsync(string bookTitle, int categoryId);

    /// <summary>
    /// Removes a book from the specified category.
    /// </summary>
    /// <param name="bookTitle">The title of the book to remove.</param>
    /// <param name="categoryName">The name of the category to remove the book from.</param>
    Task RemoveBookFromCategoryAsync(string bookTitle, string categoryName);
}


