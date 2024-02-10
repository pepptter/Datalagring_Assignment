using LibraryApp.Infrastructure.Contexts;
using LibraryApp.Infrastructure.Entities;
using LibraryApp.Infrastructure.Interfaces;
using LibraryApp.Infrastructure.Repositories;
using LibraryApp.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

public class BookCategoryRepository(LibraryContext context, ILogger logger) : Repo<BookCategoryEntity, LibraryContext>(context, logger), IBookCategoryRepository
{
    private readonly LibraryContext _context = context;
    private readonly ILogger _logger = logger;


    public async Task AddBookToCategoryAsync(string bookTitle, int categoryId)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Title == bookTitle);
        if (book != null)
        {
            var bookCategory = new BookCategoryEntity { BookID = book.BookID, CategoryID = categoryId };
            await _context.BookCategories.AddAsync(bookCategory);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddBookToCategoryAsync(int bookId, string categoryName)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
        if (category != null)
        {
            var bookCategory = new BookCategoryEntity { BookID = bookId, CategoryID = category.CategoryID };
            await _context.BookCategories.AddAsync(bookCategory);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddBookToCategoryAsync(string bookTitle, string categoryName)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Title == bookTitle);
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
        if (book != null && category != null)
        {
            var bookCategory = new BookCategoryEntity { BookID = book.BookID, CategoryID = category.CategoryID };
            await _context.BookCategories.AddAsync(bookCategory);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddBookToCategoryAsync(int bookId, int categoryId)
    {
        var book = await _context.Books.FindAsync(bookId);
        var category = await _context.Categories.FindAsync(categoryId);
        if (book != null && category != null)
        {
            var bookCategory = new BookCategoryEntity { BookID = bookId, CategoryID = categoryId };
            await _context.BookCategories.AddAsync(bookCategory);
            await _context.SaveChangesAsync();
        }
    }
    public async Task RemoveBookFromCategoryAsync(string bookTitle, int categoryId)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Title == bookTitle);
        if (book != null)
        {
            var bookCategory = await _context.BookCategories.FirstOrDefaultAsync(bc => bc.BookID == book.BookID && bc.CategoryID == categoryId);
            if (bookCategory != null)
            {
                _context.BookCategories.Remove(bookCategory);
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task RemoveBookFromCategoryAsync(string bookTitle, string categoryName)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Title == bookTitle);
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
        if (book != null && category != null)
        {
            var bookCategory = await _context.BookCategories.FirstOrDefaultAsync(bc => bc.BookID == book.BookID && bc.CategoryID == category.CategoryID);
            if (bookCategory != null)
            {
                _context.BookCategories.Remove(bookCategory);
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task RemoveBookFromCategoryAsync(int bookId, int categoryId)
    {
        var bookCategory = await _context.BookCategories.FirstOrDefaultAsync(bc => bc.BookID == bookId && bc.CategoryID == categoryId);
        if (bookCategory != null)
        {
            _context.BookCategories.Remove(bookCategory);
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveBookFromCategoryAsync(int bookId, string categoryName)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
        if (category != null)
        {
            var bookCategory = await _context.BookCategories.FirstOrDefaultAsync(bc => bc.BookID == bookId && bc.CategoryID == category.CategoryID);
            if (bookCategory != null)
            {
                _context.BookCategories.Remove(bookCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
    public override async Task<IEnumerable<BookCategoryEntity>> GetAllAsync()
    {
        return await _context.BookCategories.ToListAsync();
    }
    public async Task DeleteAsync(int bookId, int categoryId)
    {
        var bookCategory = await _context.BookCategories.FirstOrDefaultAsync(bc => bc.BookID == bookId && bc.CategoryID == categoryId);
        if (bookCategory != null)
        {
            _context.BookCategories.Remove(bookCategory);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(string bookTitle, int categoryId)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Title == bookTitle);
        if (book != null)
        {
            var bookCategory = await _context.BookCategories.FirstOrDefaultAsync(bc => bc.BookID == book.BookID && bc.CategoryID == categoryId);
            if (bookCategory != null)
            {
                _context.BookCategories.Remove(bookCategory);
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task DeleteAsync(int bookId, string categoryName)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
        if (category != null)
        {
            var bookCategory = await _context.BookCategories.FirstOrDefaultAsync(bc => bc.BookID == bookId && bc.CategoryID == category.CategoryID);
            if (bookCategory != null)
            {
                _context.BookCategories.Remove(bookCategory);
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task DeleteAsync(string bookTitle, string categoryName)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Title == bookTitle);
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
        if (book != null && category != null)
        {
            var bookCategory = await _context.BookCategories.FirstOrDefaultAsync(bc => bc.BookID == book.BookID && bc.CategoryID == category.CategoryID);
            if (bookCategory != null)
            {
                _context.BookCategories.Remove(bookCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
    public async Task<IEnumerable<BookEntity>> GetBooksByCategoryAsync(int categoryId)
    {
        return await _context.BookCategories
                               .Where(bc => bc.CategoryID == categoryId)
                               .Select(bc => bc.Book)
                               .ToListAsync();
    }

    public async Task<IEnumerable<CategoryEntity?>> GetCategoriesByBookAsync(int bookId)
    {
        return await _context.BookCategories
                               .Where(bc => bc.BookID == bookId)
                               .Select(bc => bc.Category)
                               .ToListAsync();
    }

    public async Task<IEnumerable<BookEntity>> GetBooksByCategoryAsync(string categoryName)
    {
        return await _context.Categories
                               .Where(c => c.Name == categoryName)
                               .SelectMany(c => c.BookCategories)
                               .Select(bc => bc.Book)
                               .ToListAsync();
    }

    public async Task<IEnumerable<CategoryEntity?>> GetCategoriesByBookAsync(string bookTitle)
    {
        return await _context.Books
                               .Where(b => b.Title == bookTitle)
                               .SelectMany(b => b.BookCategories)
                               .Select(bc => bc.Category)
                               .ToListAsync();
    }


}
