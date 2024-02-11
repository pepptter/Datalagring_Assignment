using LibraryApp.Business.Interfaces;
using LibraryApp.Business.Services;
using LibraryApp.Business.Utils;
using LibraryApp.ConsoleUI.Services;
using LibraryApp.Infrastructure.Contexts;
using LibraryApp.Infrastructure.Interfaces;
using LibraryApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddDbContext<LibraryContext>(x => x.UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\plugg\CSHARP\Datalagring\Datalagring_Assignment\Datalagring_Assignment\LibraryApp.Infrastructure\Data\library_database_cf.mdf; Integrated Security = True; Connect Timeout = 30"))
    .AddScoped<IUserService, UserService>()
    .AddScoped<IBookService, BookService>()
    .AddScoped<ICategoryService, CategoryService>()
    .AddScoped<IBorrowedBookService, BorrowedBookService>()
    .AddScoped<MenuService>()
    .AddScoped<UserServiceUI>()
    .AddScoped<BookServiceUI>()
    .AddScoped<CategoryServicesUI>()
    .AddScoped<BorrowServicesUI>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IBookRepository, BookRepository>()
    .AddScoped<ICategoryRepository, CategoryRepository>()
    .AddScoped<IBookCategoryRepository, BookCategoryRepository>()
    .AddScoped<IBorrowedBookRepository, BorrowedBookRepository>()
    .AddScoped<ILogger>(provider =>
    {
        var logFilePath = @"C:\plugg\CSHARP\Datalagring\Datalagring_Assignment\Datalagring_Assignment\LibraryApp.Shared\Utils\Logs\";
        return new Logger(logFilePath);
    })
    .BuildServiceProvider();


var menuService = serviceProvider.GetService<MenuService>();
if (menuService != null)
{
    await menuService.RunAsync();
}
