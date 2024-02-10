using LibraryApp.Business.Factories;
using LibraryApp.Infrastructure.Entities;
using LibraryApp.Infrastructure.Interfaces;
using LibraryApp.Business.Dtos;
using LibraryApp.Business.Interfaces;
using LibraryApp.Business.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryApp.Business.Services
{
    public class BookService(IBookRepository bookRepository, ILogger logger) : IBookService
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly ILogger _logger = logger;

        public async Task<BookDto> AddBookAsync(BookDto bookData)
        {
            try
            {
                var bookEntity = BookDtoFactory.Create(bookData);
                var addedBook = await _bookRepository.CreateAsync(bookEntity);
                return BookDtoFactory.Create(addedBook);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), "BookService.AddBookAsync()", LogTypes.Error);
                return null!;
            }
        }

        public async Task<BookDto> UpdateBookAsync(int bookId, BookDto bookData)
        {
            try
            {
                var existingBook = await _bookRepository.GetByIdAsync(bookId);
                if (existingBook == null)
                {
                    _logger.Log($"Book with ID '{bookId}' does not exist.", "BookService.UpdateBookAsync()", LogTypes.Info);
                    return null!;
                }

                existingBook.Title = bookData.Title;
                existingBook.Author = bookData.Author;
                existingBook.Published_Year = bookData.Published_Year;

                var updatedBook = await _bookRepository.UpdateAsync(b => b.BookID == bookId, existingBook);
                return BookDtoFactory.Create(updatedBook);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), "BookService.UpdateBookAsync()", LogTypes.Error);
                return null!;
            }
        }
        public async Task<bool> DeleteBookAsync(Expression<Func<BookEntity, bool>> expression)
        {
            try
            {
                var result = await _bookRepository.DeleteAsync(expression);
                return result;
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), "BookService.DeleteBookAsync()", LogTypes.Error);
                return false;
            }
        }


        public async Task<BookDto> GetBookByIdAsync(int bookId)
        {
            try
            {
                var bookEntity = await _bookRepository.GetByIdAsync(bookId);
                if (bookEntity == null)
                {
                    _logger.Log($"Book with ID '{bookId}' does not exist.", "BookService.GetBookByIdAsync()", LogTypes.Info);
                    return null!;
                }

                return BookDtoFactory.Create(bookEntity);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), "BookService.GetBookByIdAsync()", LogTypes.Error);
                return null!;
            }
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            try
            {
                var books = await _bookRepository.GetAllAsync();
                return books.Select(BookDtoFactory.Create);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), "BookService.GetAllBooksAsync()", LogTypes.Error);
                return Enumerable.Empty<BookDto>();
            }
        }

        public async Task<IEnumerable<BookDto>> FindBooksByAuthorAsync(string author)
        {
            try
            {
                var books = await _bookRepository.FindByAuthorAsync(author);
                return books.Select(BookDtoFactory.Create);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), "BookService.FindBooksByAuthorAsync()", LogTypes.Error);
                return Enumerable.Empty<BookDto>();
            }
        }

        public async Task<IEnumerable<BookDto>> FindBooksByTitleAsync(string title)
        {
            try
            {
                var books = await _bookRepository.FindAllContainingTitleAsync(title);
                return books.Select(BookDtoFactory.Create);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), "BookService.FindBooksByTitleAsync()", LogTypes.Error);
                return Enumerable.Empty<BookDto>();
            }
        }

        public async Task<IEnumerable<BookDto>> FindBooksByCategoryAsync(int categoryId)
        {
            try
            {
                var books = await _bookRepository.GetAllBooksByCategoryAsync(categoryId);
                return books.Select(BookDtoFactory.Create);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), "BookService.FindBooksByCategoryAsync()", LogTypes.Error);
                return Enumerable.Empty<BookDto>();
            }
        }
    }
}
