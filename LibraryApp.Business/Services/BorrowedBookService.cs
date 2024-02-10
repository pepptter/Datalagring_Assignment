using LibraryApp.Infrastructure.Interfaces;
using LibraryApp.Business.Dtos;
using LibraryApp.Business.Interfaces;
using LibraryApp.Business.Factories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApp.Business.Utils;
using LibraryApp.Infrastructure.Entities;

namespace LibraryApp.Business.Services
{
    public class BorrowedBookService(IBorrowedBookRepository borrowedBookRepository, ILogger logger) : IBorrowedBookService
    {
        private readonly IBorrowedBookRepository _borrowedBookRepository = borrowedBookRepository;
        private readonly ILogger _logger = logger;

        public async Task<IEnumerable<BorrowedBookDto>> GetAllBorrowedBooksAsync()
        {
            try
            {
                var borrowedBooks = await _borrowedBookRepository.GetAllBorrowedBooksAsync();
                return borrowedBooks.Select(BorrowedBookDtoFactory.Create);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), "BorrowedBookService.GetAllBorrowedBooksAsync()", LogTypes.Error);
                return new List<BorrowedBookDto>();
            }
        }

        public async Task<bool> ExtendBorrowTimeAsync(int borrowId, int additionalDays)
        {
            try
            {
                var borrowedBook = await _borrowedBookRepository.GetByIdAsync(borrowId);
                if (borrowedBook == null)
                {
                    _logger.Log($"Borrowed book with ID '{borrowId}' not found.", "BorrowService.ExtendBorrowTimeAsync()", LogTypes.Info);
                    return false;
                }

                borrowedBook.ReturnDate = borrowedBook.ReturnDate.AddDays(additionalDays);
                await _borrowedBookRepository.UpdateAsync(b => b.BorrowID == borrowId, borrowedBook);

                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), "BorrowService.ExtendBorrowTimeAsync()", LogTypes.Error);
                return false;
            }
        }

        public async Task<bool> BorrowBookAsync(int userId, int bookId, DateTime borrowDate, DateTime returnDate)
        {
            try
            {
                var borrowedBook = new BorrowedBookEntity
                {
                    UserID = userId,
                    BookID = bookId,
                    BorrowDate = borrowDate,
                    ReturnDate = returnDate
                };

                await _borrowedBookRepository.CreateAsync(borrowedBook);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), "BorrowService.BorrowBookAsync()", LogTypes.Error);
                return false;
            }
        }
        public async Task<bool> ReturnBookAsync(int borrowId)
        {
            try
            {
                var borrowedBook = await _borrowedBookRepository.GetByIdAsync(borrowId);
                if (borrowedBook == null)
                {
                    _logger.Log($"Borrowed book with ID '{borrowId}' not found.", "BorrowService.ReturnBookAsync()", LogTypes.Info);
                    return false;
                }

                await _borrowedBookRepository.DeleteAsync(b => b.BorrowID == borrowId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), "BorrowService.ReturnBookAsync()", LogTypes.Error);
                return false;
            }
        }

    }
}
