using LibraryApp.Infrastructure.Contexts;
using LibraryApp.Infrastructure.Entities;
using LibraryApp.Infrastructure.Repositories;
using LibraryApp.Shared.Interfaces;

public class BorrowedBookRepository(LibraryContext context, ILogger logger) : Repo<BorrowedBookEntity, LibraryContext>(context, logger), IBorrowedBookRepository
{
    private readonly LibraryContext _libraryContext = context;
    private readonly ILogger _logger = logger;
}
