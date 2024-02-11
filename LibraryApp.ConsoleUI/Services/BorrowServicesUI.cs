using LibraryApp.Business.Interfaces;


namespace LibraryApp.ConsoleUI.Services;

public class BorrowServicesUI(IBorrowedBookService borrowedBookService)
{
    private readonly IBorrowedBookService _borrowedBookService = borrowedBookService;

    public async Task ManageBorrowsAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Manage Borrows");
            Console.WriteLine("1. View all borrows");
            Console.WriteLine("2. Add a borrow");
            Console.WriteLine("3. Extend a borrow");
            Console.WriteLine("4. Delete a borrow");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    await ViewAllBorrowsAsync();
                    break;
                case "2":
                    await AddBorrowAsync();
                    break;
                case "3":
                    await ExtendBorrowAsync();
                    break;
                case "4":
                    await ReturnBorrowAsync();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
    private async Task ViewAllBorrowsAsync()
    {
        var borrows = await _borrowedBookService.GetAllBorrowedBooksAsync();
        if (borrows.Any())
        {
            Console.WriteLine("Borrows:");
            foreach (var borrow in borrows)
            {
                Console.WriteLine($"Borrow ID: {borrow.BorrowID}, User ID: {borrow.UserID}, Book ID: {borrow.BookID}, Borrow Date: {borrow.BorrowDate}, Return Date: {borrow.ReturnDate}");
            }
        }
        else
        {
            Console.WriteLine("No borrows found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    private async Task AddBorrowAsync()
    {
        Console.WriteLine("Enter user ID:");
        if (!int.TryParse(Console.ReadLine(), out int userID))
        {
            Console.WriteLine("Invalid input for user ID.");
            return;
        }

        Console.WriteLine("Enter book ID:");
        if (!int.TryParse(Console.ReadLine(), out int bookID))
        {
            Console.WriteLine("Invalid input for book ID.");
            return;
        }

        var isSuccess = await _borrowedBookService.BorrowBookAsync(userID, bookID, DateTime.Now, DateTime.Now.AddDays(14));
        if (!isSuccess)
        {
            Console.WriteLine("Failed to borrow the book. Please check the provided user and book IDs.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Borrow added successfully. Press any key to continue...");
        Console.ReadKey();
    }

    private async Task ExtendBorrowAsync()
        {
            Console.WriteLine("Enter the ID of the borrow you want to extend:");
            if (!int.TryParse(Console.ReadLine(), out int borrowID))
                {
                    Console.WriteLine("Invalid input for borrow ID.");
                    return;
                }
        
            var result = await _borrowedBookService.ExtendBorrowTimeAsync(borrowID);
            if (result)
                {
                    Console.WriteLine("Borrowtime extended by 14 days.");
                }
            else
                {
                    Console.WriteLine("Failed to extend borrow or borrow not found.");
                }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    private async Task ReturnBorrowAsync()
    {
        Console.WriteLine("Enter the ID of the borrow you want to return:");
        if (!int.TryParse(Console.ReadLine(), out int borrowID))
        {
            Console.WriteLine("Invalid input for borrow ID.");
            return;
        }

        var result = await _borrowedBookService.ReturnBookAsync(borrowID);
        if (result)
        {
            Console.WriteLine("Borrow returned successfully.");
        } 
        else
        {
            Console.WriteLine("Failed to return borrow or borrow not found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

}
