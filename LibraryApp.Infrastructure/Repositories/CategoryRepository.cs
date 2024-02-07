using LibraryApp.Infrastructure.Contexts;
using LibraryApp.Infrastructure.Entities;
using LibraryApp.Infrastructure.Repositories;
using LibraryApp.Shared.Interfaces;

public class CategoryRepository(LibraryContext context, ILogger logger) : Repo<CategoryEntity, LibraryContext>(context, logger), ICategoryRepository
{
    private readonly LibraryContext _libraryContext = context;
    private readonly ILogger _logger = logger;
}
