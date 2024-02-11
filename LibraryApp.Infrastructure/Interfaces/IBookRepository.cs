using LibraryApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Interfaces
{
    public interface IBookRepository : IRepo<BookEntity>
    {
        /// <summary>
        /// Finds books by author.
        /// </summary>
        /// <param name="author">The author's name.</param>
        /// <returns>A collection of books written by the specified author.</returns>
        Task<IEnumerable<BookEntity>> FindByAuthorAsync(string author);

        /// <summary>
        /// Finds a book by its ID asynchronously.
        /// </summary>
        /// <param name="bookId">The ID of the book to find.</param>
        /// <returns>A task representing the asynchronous operation that returns the found book entity, or null if not found.</returns>
        Task<BookEntity?> FindBookByIdAsync(int bookId);

        /// <summary>
        /// Finds the first book with a title containing the specified text.
        /// </summary>
        /// <param name="title">The text to search for in book titles.</param>
        /// <returns>The first book entity with a title containing the specified text, or null if not found.</returns>
        Task<BookEntity> FindFirstByTitleAsync(string title);

        /// <summary>
        /// Finds all books with titles containing the specified text.
        /// </summary>
        /// <param name="title">The text to search for in book titles.</param>
        /// <returns>A collection of books with titles containing the specified text.</returns>
        Task<IEnumerable<BookEntity>> FindAllContainingTitleAsync(string title);

        /// <summary>
        /// Retrieves all book entities from the repository.
        /// </summary>
        /// <returns>A collection of all book entities.</returns>

        new Task<IEnumerable<BookEntity>> GetAllAsync();

        /// <summary>
        /// Retrieves all books belonging to the specified category from the repository.
        /// </summary>
        /// <param name="categoryId">The ID of the category.</param>
        /// <returns>A collection of all book entities belonging to the specified category.</returns>

        Task<IEnumerable<BookEntity>> GetAllBooksByCategoryAsync(int categoryId);

        /// <summary>
        /// Finds books by category name.
        /// </summary>
        /// <param name="categoryName">The name of the category.</param>
        /// <returns>A collection of books belonging to the specified category.</returns>
        Task<IEnumerable<BookEntity>> FindBooksByCategoryNameAsync(string categoryName);
    }
}
