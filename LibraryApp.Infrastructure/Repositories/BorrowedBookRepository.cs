using LibraryApp.Infrastructure.Contexts;
using LibraryApp.Infrastructure.Entities;
using LibraryApp.Infrastructure.Repositories;
using LibraryApp.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LibraryApp.Infrastructure.Interfaces;
public class BorrowedBookRepository(LibraryContext context, ILogger logger) : Repo<BorrowedBookEntity, LibraryContext>(context, logger), IBorrowedBookRepository
{
    private readonly LibraryContext _context = context;
    private readonly ILogger _logger = logger;


    public async Task<BorrowedBookEntity> AddBorrowedBookAsync(BorrowedBookEntity borrowedBook)
    {
        try
        {
            _context.BorrowedBooks.Add(borrowedBook);
            await _context.SaveChangesAsync();
            return borrowedBook;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BorrowedBookRepository.AddBorrowedBookAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return null!;
        }
    }
    public async Task<bool> RemoveBorrowedBookAsync(int borrowedBookId, int userId)
    {
        try
        {
            var borrowedBook = await _context.BorrowedBooks.FirstOrDefaultAsync(b => b.Book.BookID == borrowedBookId && b.User.UserID == userId);
            if (borrowedBook != null)
            {
                _context.BorrowedBooks.Remove(borrowedBook);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BorrowedBookRepository.RemoveBorrowedBookAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return false;
        }
    }
    public async Task<bool> RemoveBorrowedBookAsync(string bookTitle, int userId)
    {
        try
        {
            var borrowedBook = await _context.BorrowedBooks.FirstOrDefaultAsync(b => b.Book.Title == bookTitle && b.User.UserID == userId);
            if (borrowedBook != null)
            {
                _context.BorrowedBooks.Remove(borrowedBook);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BorrowedBookRepository.RemoveBorrowedBookAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return false;
        }
    }
    public async Task<IEnumerable<BorrowedBookEntity>> GetBorrowedBooksByUserIdAsync(int userId)
    {
        try
        {
            return await _context.BorrowedBooks
                                 .Where(b => b.User.UserID == userId)
                                 .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BorrowedBookRepository.GetBorrowedBooksByUserIdAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return new List<BorrowedBookEntity>();
        }
    }
    public async Task<IEnumerable<BorrowedBookEntity>> GetBorrowedBooksByBookIdAsync(int bookId)
    {
        try
        {
            return await _context.BorrowedBooks
                                 .Where(b => b.Book.BookID == bookId)
                                 .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BorrowedBookRepository.GetBorrowedBooksByBookIdAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return new List<BorrowedBookEntity>();
        }
    }
    public async Task<IEnumerable<BorrowedBookEntity>> GetBorrowedBooksByDateAsync(DateTime date)
    {
        try
        {
            return await _context.BorrowedBooks
                                 .Where(b => b.BorrowDate.Date == date.Date)
                                 .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BorrowedBookRepository.GetBorrowedBooksByDateAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return new List<BorrowedBookEntity>();
        }
    }
    public async Task<IEnumerable<BorrowedBookEntity>> GetAllBorrowedBooksAsync()
    {
        try
        {
            return await _context.BorrowedBooks.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BorrowedBookRepository.GetAllBorrowedBooksAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return Enumerable.Empty<BorrowedBookEntity>();
        }
    }
    public async Task<IEnumerable<BorrowedBookEntity>> GetOverdueBorrowedBooksAsync()
    {
        try
        {
            var currentDate = DateTime.Now;
            return await _context.BorrowedBooks
                                         .Where(b => b.ReturnDate < currentDate)
                                         .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BorrowedBookRepository.GetOverdueBorrowedBooksAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return Enumerable.Empty<BorrowedBookEntity>();
        }
    }
    public async Task<bool> RenewBorrowedBookAsync(int borrowedBookId, DateTime newReturnDate)
    {
        try
        {
            var borrowedBook = await _context.BorrowedBooks.FindAsync(borrowedBookId);
            if (borrowedBook != null)
            {
                borrowedBook.ReturnDate = newReturnDate;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BorrowedBookRepository.RenewBorrowedBookAsync()", LibraryApp.Shared.Utils.LogTypes.Error);
            return false;
        }
    }

}