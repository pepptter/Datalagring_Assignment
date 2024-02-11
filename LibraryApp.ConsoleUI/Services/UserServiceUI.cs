using LibraryApp.Business.Dtos;
using LibraryApp.Business.Interfaces;


namespace LibraryApp.ConsoleUI.Services;


public class UserServiceUI(IUserService userService)
{
    private readonly IUserService _userService = userService;

    public async Task ManageUsersAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Manage Users");
            Console.WriteLine("1. View all users");
            Console.WriteLine("2. Get a user by ID");
            Console.WriteLine("3. Add a user");
            Console.WriteLine("4. Update a user");
            Console.WriteLine("5. Delete a user");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    await ViewAllUsersAsync();
                    break;
                case "2":
                    await GetUserByIdAsync();
                    break;
                case "3":
                    await AddUserAsync();
                    break;
                case "4":
                    await UpdateUserAsync();
                    break;
                case "5":
                    await DeleteUserAsync();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }


    private async Task ViewAllUsersAsync()
    {
        var users = await _userService.GetAllUsersAsync();
        if (users.Any())
        {
            foreach (var user in users)
            {
                Console.Write($"ID: {user.UserID}, Name: {user.FirstName} {user.LastName}, Email: {user.Email}");
                if (!string.IsNullOrEmpty(user.PhoneNumber))
                {
                    Console.Write($" Phone: {user.PhoneNumber}");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No users found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    private async Task AddUserAsync()
    {
        Console.WriteLine("Enter first name:");
        string firstName = Console.ReadLine()!;

        Console.WriteLine("Enter last name:");
        string lastName = Console.ReadLine()!;

        Console.WriteLine("Enter email: ");
        string email = Console.ReadLine()!;

        Console.WriteLine("Enter phone number (optional):");
        string phoneNumber = Console.ReadLine()!;

        if (string.IsNullOrEmpty(phoneNumber))
        {
            phoneNumber = null!;
        }

        if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(email))
        {
            var result = await _userService.RegisterUserAsync(new UserDto { FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = phoneNumber });
            if (result != null)
            {
                Console.WriteLine("User added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add user. The email might already be in use.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please provide all required information.");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public async Task<UserDto> GetUserByIdAsync()
    {
        Console.WriteLine("Enter the ID of the user you want to find:");

        if (!int.TryParse(Console.ReadLine(), out int userId))
        {
            Console.WriteLine("Invalid input for user ID.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return null!;
        }

        var user = await _userService.GetUserByIdAsync(userId);
        if (user != null)
        {
            Console.WriteLine($"User found - ID: {user.UserID}, Name: {user.FirstName} {user.LastName}, Email: {user.Email}");
        }
        else
        {
            Console.WriteLine($"No user found with ID: {userId}");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return user!;
    }

    private async Task UpdateUserAsync()
    {
        Console.WriteLine("Enter the ID of the user you want to update:");
        var userInput = Console.ReadLine();
        if (!int.TryParse(userInput, out int userId))
        {
            Console.WriteLine("Invalid input for user ID.");
            return;
        }

        Console.WriteLine("Enter new first name (leave blank to keep current):");
        string firstName = Console.ReadLine()!;

        Console.WriteLine("Enter new last name (leave blank to keep current):");
        string lastName = Console.ReadLine()!;

        Console.WriteLine("Enter new email (leave blank to keep current):");
        string email = Console.ReadLine()!;
        Console.WriteLine("Enter new phonenumber (leave blank to keep current):");
        string phoneNumber = Console.ReadLine()!;

        var existingUser = await _userService.GetUserByIdAsync(userId);
        if (existingUser == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        var updatedUser = new UserDto
        {
            UserID = userId,
            FirstName = string.IsNullOrEmpty(firstName) ? existingUser.FirstName : firstName,
            LastName = string.IsNullOrEmpty(lastName) ? existingUser.LastName : lastName,
            Email = string.IsNullOrEmpty(email) ? existingUser.Email : email,
            PhoneNumber = string.IsNullOrEmpty(phoneNumber) ? existingUser.PhoneNumber : phoneNumber
        };

        await _userService.UpdateUserAsync(userId, updatedUser);

        Console.WriteLine($"User with ID: {updatedUser.UserID} updated successfully. Press any key to continue...");
        Console.ReadKey();
    }

    private async Task DeleteUserAsync()
    {
        Console.WriteLine("Enter the ID of the user you want to delete:");
        if (!int.TryParse(Console.ReadLine(), out int userId))
        {
            Console.WriteLine("Invalid input for user ID.");
            return;
        }

        var result = await _userService.DeleteUserAsync(userId);
        if (result)
        {
            Console.WriteLine("User deleted successfully.");
        }
        else
        {
            Console.WriteLine("Failed to delete user or user not found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
