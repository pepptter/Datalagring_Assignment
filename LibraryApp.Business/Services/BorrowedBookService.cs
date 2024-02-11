using LibraryApp.Infrastructure.Interfaces;
using LibraryApp.Business.Dtos;
using LibraryApp.Business.Interfaces;
using LibraryApp.Business.Factories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApp.Business.Utils;
using LibraryApp.Infrastructure.Entities;
using LibraryApp.Infrastructure.Repositories;

namespace LibraryApp.Business.Services
{
    public class BorrowedBookService(IBorrowedBookRepository borrowedBookRepository, ILogger logger, IUserRepository userRepository, IBookRepository bookRepository) : IBorrowedBookService
    {
        private readonly IBorrowedBookRepository _borrowedBookRepository = borrowedBookRepository;
        private readonly ILogger _logger = logger;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IBookRepository _bookRepository = bookRepository;

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

        public async Task<bool> ExtendBorrowTimeAsync(int borrowId)
        {
            try
            {
                var borrowedBook = await _borrowedBookRepository.GetByIdAsync(borrowId);
                if (borrowedBook == null)
                {
                    _logger.Log($"Borrowed book with ID '{borrowId}' not found.", "BorrowService.ExtendBorrowTimeAsync()", LogTypes.Info);
                    return false;
                }

                borrowedBook.ReturnDate = borrowedBook.ReturnDate.AddDays(14);
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
                var userExists = await _userRepository.GetUserByIdAsync(userId);
                if (userExists == null)
                {
                    _logger.Log($"User with ID '{userId}' does not exist.", "BorrowService.BorrowBookAsync()", LogTypes.Info);
                    return false;
                }

                var bookExists = await _bookRepository.FindBookByIdAsync(bookId);
                if (bookExists == null)
                {
                    _logger.Log($"Book with ID '{bookId}' does not exist.", "BorrowService.BorrowBookAsync()", LogTypes.Info);
                    return false;
                }

                var borrowedBookEntity = new BorrowedBookEntity
                {
                    UserID = userId,
                    BookID = bookId,
                    BorrowDate = borrowDate,
                    ReturnDate = returnDate
                };
                await _borrowedBookRepository.CreateAsync(borrowedBookEntity);

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
