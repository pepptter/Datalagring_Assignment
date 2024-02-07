using LibraryApp.Infrastructure.Contexts;
using LibraryApp.Infrastructure.Entities;
using LibraryApp.Infrastructure.Interfaces;
using LibraryApp.Infrastructure.Repositories;
using LibraryApp.Shared.Interfaces;

public class BookCategoryRepository(LibraryContext context, ILogger logger) : Repo<BookCategoryEntity, LibraryContext>(context, logger), IBookCategoryRepository
{
    private readonly LibraryContext _libraryContext = context;
    private readonly ILogger _logger = logger;
}
