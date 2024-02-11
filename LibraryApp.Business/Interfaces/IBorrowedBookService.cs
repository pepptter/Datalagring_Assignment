using LibraryApp.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Business.Interfaces
{
    public interface IBorrowedBookService
    {
        /// <summary>
        /// Retrieves all borrowed books in the library.
        /// </summary>
        /// <returns>A collection of all borrowed books.</returns>
        Task<IEnumerable<BorrowedBookDto>> GetAllBorrowedBooksAsync();

        /// <summary>
        /// Extends the return date of a borrowed book.
        /// </summary>
        /// <param name="borrowId">The ID of the borrowed book.</param>
        /// <param name="additionalDays">The number of additional days to extend the return date by.</param>
        /// <returns>True if the extension was successful, otherwise false.</returns>
        Task<bool> ExtendBorrowTimeAsync(int borrowId);

        /// <summary>
        /// Borrows a book from the library.
        /// </summary>
        /// <param name="userId">The ID of the user borrowing the book.</param>
        /// <param name="bookId">The ID of the book being borrowed.</param>
        /// <param name="borrowDate">The date the book is borrowed.</param>
        /// <param name="returnDate">The expected return date for the book.</param>
        /// <returns>True if the book was successfully borrowed, otherwise false.</returns>
        Task<bool> BorrowBookAsync(int userId, int bookId, DateTime borrowDate, DateTime returnDate);

        /// <summary>
        /// Returns a borrowed book to the library.
        /// </summary>
        /// <param name="borrowId">The ID of the borrowed book to be returned.</param>
        /// <returns>True if the book was successfully returned, otherwise false.</returns>
        Task<bool> ReturnBookAsync(int borrowId);
    }
}
