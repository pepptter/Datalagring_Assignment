using LibraryApp.Business.Dtos;
using LibraryApp.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.ConsoleUI.Services;

public class MenuService(IUserService userService, IBookService bookService, ICategoryService categoryService, IBorrowedBookService borrowedBookService, UserServiceUI userServicesUI, BookServiceUI bookServicesUI, CategoryServicesUI categoryServicesUI, BorrowServicesUI borrowServicesUI)
{
    private readonly IUserService _userService = userService;
    private readonly IBookService _bookService = bookService;
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IBorrowedBookService _borrowedBookService = borrowedBookService;
    private readonly UserServiceUI _userServicesUI = userServicesUI;
    private readonly BookServiceUI _bookServicesUI = bookServicesUI;
    private readonly CategoryServicesUI _categoryServicesUI = categoryServicesUI;
    private readonly BorrowServicesUI _borrowServicesUI = borrowServicesUI;


    public async Task RunAsync()     
    {
        bool running = true;
        while (running)
        { 
            Console.Clear();
            Console.WriteLine("Welcome to the Library Application");
            Console.WriteLine("1. Manage Users");
            Console.WriteLine("2. Manage Books");
            Console.WriteLine("3. Manage Categories");
            Console.WriteLine("4. Manage Borrows");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    await _userServicesUI.ManageUsersAsync();
                    break;
                case "2":
                    await _bookServicesUI.ManageBooksAsync();
                    break;
                case "3":
                    await _categoryServicesUI.ManageCategoriesAsync();                    
                    break;
                case "4":
                    await _borrowServicesUI.ManageBorrowsAsync();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    


}
