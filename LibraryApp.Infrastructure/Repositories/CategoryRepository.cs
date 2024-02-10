using LibraryApp.Infrastructure.Contexts;
using LibraryApp.Infrastructure.Entities;
using LibraryApp.Infrastructure.Repositories;
using LibraryApp.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Infrastructure.Interfaces;
public class CategoryRepository(LibraryContext context, ILogger logger) : Repo<CategoryEntity, LibraryContext>(context, logger), ICategoryRepository
{
    private readonly LibraryContext _context = context;
    private readonly ILogger _logger = logger;

    public async Task<CategoryEntity> AddCategoryAsync(CategoryEntity category)
    {
        try
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryRepository.AddCategoryAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return null!;
        }
    }
    public async Task<bool> AddBookToCategoryAsync(int bookId, int categoryId)
    {
        try
        {
            var bookCategory = new BookCategoryEntity { BookID = bookId, CategoryID = categoryId };
            await _context.BookCategories.AddAsync(bookCategory);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryRepository.AddBookToCategoryAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return false;
        }
    }
    public async Task<CategoryEntity?> GetCategoryByIdAsync(int categoryId)
    {
        try
        {
            return await _context.Categories.FindAsync(categoryId);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryRepository.GetCategoryByIdAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return null!;
        }
    }
   
    public async Task<CategoryEntity?> GetCategoryByNameAsync(string categoryName)
    {
        try
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryRepository.GetCategoryByNameAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return null!;
        }
    }
    public async Task<IEnumerable<BookEntity>> GetBooksByCategoryAsync(int categoryId)
    {
        try
        {
            return await _context.BookCategories
                .Where(bc => bc.CategoryID == categoryId)
                .Select(bc => bc.Book)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryRepository.GetBooksByCategoryAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return Enumerable.Empty<BookEntity>();
        }
    }
    public async Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category)
    {
        try
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryRepository.UpdateCategoryAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return null!;
        }
    }
    public async Task<bool> RemoveCategoryAsync(int categoryId)
    {
        try
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryRepository.RemoveCategoryAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return false;
        }
    }
    public async Task<bool> RemoveCategoryAsync(string categoryName)
    {
        try
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryRepository.RemoveCategoryAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return false;
        }
    }
    public async Task<bool> RemoveBookFromCategoryAsync(int bookId, int categoryId)
    {
        try
        {
            var bookCategory = await _context.BookCategories.FirstOrDefaultAsync(bc => bc.BookID == bookId && bc.CategoryID == categoryId);
            if (bookCategory != null)
            {
                _context.BookCategories.Remove(bookCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryRepository.RemoveBookFromCategoryAsync()", LibraryApp.Business.Utils.LogTypes.Error);
            return false;
        }
    }

}
