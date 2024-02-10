using LibraryApp.Business.Dtos;
using LibraryApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryApp.Business.Interfaces;
public interface IBookService
{
    /// <summary>
    /// Adds a new book to the library.
    /// </summary>
    /// <param name="bookData">Data of the book to be added.</param>
    /// <returns>The newly added book.</returns>
    Task<BookDto> AddBookAsync(BookDto bookData);

    /// <summary>
    /// Updates an existing book in the library.
    /// </summary>
    /// <param name="bookId">The ID of the book to be updated.</param>
    /// <param name="bookData">New data for the book.</param>
    /// <returns>The updated book.</returns>
    Task<BookDto> UpdateBookAsync(int bookId, BookDto bookData);

    /// <summary>
    /// Deletes a book from the library based on the provided expression.
    /// </summary>
    /// <param name="expression">The expression to filter books for deletion.</param>
    /// <returns>True if the deletion was successful, otherwise false.</returns>
    Task<bool> DeleteBookAsync(Expression<Func<BookEntity, bool>> expression);

    /// <summary>
    /// Retrieves a book by its ID.
    /// </summary>
    /// <param name="bookId">The ID of the book to retrieve.</param>
    /// <returns>The book with the specified ID, or null if not found.</returns>
    Task<BookDto> GetBookByIdAsync(int bookId);

    /// <summary>
    /// Retrieves all books in the library.
    /// </summary>
    /// <returns>A collection of all books in the library.</returns>
    Task<IEnumerable<BookDto>> GetAllBooksAsync();

    /// <summary>
    /// Finds books written by a specific author.
    /// </summary>
    /// <param name="author">The author's name.</param>
    /// <returns>A collection of books written by the specified author.</returns>
    Task<IEnumerable<BookDto>> FindBooksByAuthorAsync(string author);

    /// <summary>
    /// Finds books with titles containing the specified text.
    /// </summary>
    /// <param name="title">The text to search for in book titles.</param>
    /// <returns>A collection of books with titles containing the specified text.</returns>
    Task<IEnumerable<BookDto>> FindBooksByTitleAsync(string title);

    /// <summary>
    /// Finds books belonging to a specific category.
    /// </summary>
    /// <param name="categoryId">The ID of the category.</param>
    /// <returns>A collection of books belonging to the specified category.</returns>
    Task<IEnumerable<BookDto>> FindBooksByCategoryAsync(int categoryId);
}