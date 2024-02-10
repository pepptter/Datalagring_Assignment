using LibraryApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Interfaces
{
    public interface IBorrowedBookRepository : IRepo<BorrowedBookEntity>
    {
        /// <summary>
        /// Adds a new borrowed book to the repository.
        /// </summary>
        /// <param name="borrowedBook">The borrowed book entity to add.</param>
        /// <returns>The added borrowed book entity.</returns>
        Task<BorrowedBookEntity> AddBorrowedBookAsync(BorrowedBookEntity borrowedBook);

        /// <summary>
        /// Removes a borrowed book by its ID and user ID.
        /// </summary>
        /// <param name="borrowedBookId">The ID of the borrowed book to remove.</param>
        /// <param name="userId">The ID of the user who borrowed the book.</param>
        /// <returns>True if the borrowed book was successfully removed, otherwise false.</returns>
        Task<bool> RemoveBorrowedBookAsync(int borrowedBookId, int userId);

        /// <summary>
        /// Removes a borrowed book by its title and user ID.
        /// </summary>
        /// <param name="bookTitle">The title of the borrowed book to remove.</param>
        /// <param name="userId">The ID of the user who borrowed the book.</param>
        /// <returns>True if the borrowed book was successfully removed, otherwise false.</returns>
        Task<bool> RemoveBorrowedBookAsync(string bookTitle, int userId);

        /// <summary>
        /// Retrieves all borrowed books by user ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A collection of borrowed book entities by the specified user ID.</returns>
        Task<IEnumerable<BorrowedBookEntity>> GetBorrowedBooksByUserIdAsync(int userId);

        /// <summary>
        /// Retrieves all borrowed books by book ID.
        /// </summary>
        /// <param name="bookId">The ID of the book.</param>
        /// <returns>A collection of borrowed book entities by the specified book ID.</returns>
        Task<IEnumerable<BorrowedBookEntity>> GetBorrowedBooksByBookIdAsync(int bookId);

        /// <summary>
        /// Retrieves all borrowed books by date.
        /// </summary>
        /// <param name="date">The date of borrowing.</param>
        /// <returns>A collection of borrowed book entities by the specified date.</returns>
        Task<IEnumerable<BorrowedBookEntity>> GetBorrowedBooksByDateAsync(DateTime date);

        /// <summary>
        /// Retrieves all borrowed books from the repository.
        /// </summary>
        /// <returns>A collection of all borrowed book entities.</returns>
        Task<IEnumerable<BorrowedBookEntity>> GetAllBorrowedBooksAsync();

        /// <summary>
        /// Retrieves all overdue borrowed books from the repository.
        /// </summary>
        /// <returns>A collection of all overdue borrowed book entities.</returns>
        Task<IEnumerable<BorrowedBookEntity>> GetOverdueBorrowedBooksAsync();

        /// <summary>
        /// Renews the borrowing period for a specific borrowed book.
        /// </summary>
        /// <param name="borrowedBookId">The ID of the borrowed book to renew.</param>
        /// <param name="newReturnDate">The new return date for the borrowed book.</param>
        /// <returns>True if the borrowing period was successfully renewed, otherwise false.</returns>
        Task<bool> RenewBorrowedBookAsync(int borrowedBookId, DateTime newReturnDate);

        /// <summary>
        /// Updates the return date for a specific borrowed book.
        /// </summary>
        /// <param name="borrowedBookId">The ID of the borrowed book to update.</param>
        /// <param name="newReturnDate">The new return date for the borrowed book.</param>
        /// <returns>True if the return date was successfully updated, otherwise false.</returns>
        Task<bool> UpdateBorrowedBookAsync(int borrowedBookId, DateTime newReturnDate);
    }
}
