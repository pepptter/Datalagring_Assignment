using LibraryApp.Infrastructure.Contexts;
using LibraryApp.Infrastructure.Entities;
using LibraryApp.Infrastructure.Interfaces;
using LibraryApp.Infrastructure.Repositories;
using LibraryApp.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class BookRepository(LibraryContext context, ILogger logger) : Repo<BookEntity, LibraryContext>(context, logger), IBookRepository
{
    private readonly LibraryContext _context = context;
    private readonly ILogger _logger = logger;

    public async Task<IEnumerable<BookEntity>> FindByAuthorAsync(string author)
    {
        try
        {
            if (string.IsNullOrEmpty(author))
            {
                return new List<BookEntity>();
            }

            return await _context.Books
                                 .Where(book => book.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                                 .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BookRepository.FindByAuthorAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return new List<BookEntity>();
        }
    }
    public async Task<BookEntity> FindFirstByTitleAsync(string title)
    {
        try
        {
            if (string.IsNullOrEmpty(title))
            {
                return null!;
            }

            var bookEntity = await _context.Books
                                         .FirstOrDefaultAsync(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

            if (bookEntity == null)
            {
                return null!;
            }
            return bookEntity;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BookRepository.FindFirstByTitleAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return null!;
        }
    }
    public async Task<IEnumerable<BookEntity>> FindAllContainingTitleAsync(string title)
    {
        try
        {
            return await _context.Books
                                 .Where(book => book.Title.Contains(title))
                                 .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BookRepository.FindAllContainingTitleAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return new List<BookEntity>();
        }
    }

    public override async Task<IEnumerable<BookEntity>> GetAllAsync()
    {
        try
        {
            return await _context.Books
                                 .Include(book => book.BookCategories)
                                     .ThenInclude(bc => bc.Category)
                                 .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(ex.Message, "BookRepository.GetAllAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return new List<BookEntity>();
        }
    }
    public async Task<IEnumerable<BookEntity>> GetAllBooksByCategoryAsync(int categoryID)
    {
        try
        {
            return await _context.Books
                                 .Where(book => book.BookCategories.Any(bc => bc.CategoryID == categoryID))
                                 .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BookRepository.GetAllBooksByCategoryAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return new List<BookEntity>();
        }
    }
}
