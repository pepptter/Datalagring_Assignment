using LibraryApp.Business.Factories;
using LibraryApp.Infrastructure.Interfaces;
using LibraryApp.Business.Dtos;
using LibraryApp.Business.Interfaces;
using LibraryApp.Business.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Business.Services;

public class UserService(IUserRepository userRepository, ILogger logger, IBorrowedBookRepository borrowedBookRepository, IBookRepository bookRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ILogger _logger = logger;
    private readonly IBorrowedBookRepository _borrowedBookRepository = borrowedBookRepository;
    private readonly IBookRepository _bookRepository = bookRepository;

    public async Task<UserDto> RegisterUserAsync(UserDto userData)
    {
        try
        {
            var existingUser = await _userRepository.GetUserByUserEmailAsync(userData.Email);
            if (existingUser != null)
            {
                _logger.Log($"User with email '{userData.Email}' already exists.", "UserService.RegisterUserAsync()", LogTypes.Info);
                return null!;
            }
            var userEntity = UserDtoFactory.Create(userData);
            var addedUser = await _userRepository.AddUserAsync(userEntity);
            return UserDtoFactory.Create(addedUser);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "UserService.RegisterUserAsync()", LogTypes.Error);
            return null!;
        }
    }

    public async Task<UserDto> GetUserByIdAsync(int userId)
    {
        try
        {
            var userEntity = await _userRepository.GetUserByIdAsync(userId);
            if (userEntity == null)
            {
                _logger.Log($"User with ID '{userId}' does not exist.", "UserService.GetUserByIdAsync()", LogTypes.Info);
                return null!;
            }

            return UserDtoFactory.Create(userEntity);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "UserService.GetUserByIdAsync()", LogTypes.Error);
            return null!;
        }
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        try
        {
            var users = await _userRepository.GetAllUsersAsync();
            if (users != null)
            {
                var list = new List<UserDto>();
                foreach (var user in users)
                {
                    list.Add(UserDtoFactory.Create(user));
                }
                return list;
            }
            else
            {
                _logger.Log("No users found.", "UserService.GetAllUsersAsync()", LogTypes.Info);
                return Enumerable.Empty<UserDto>();
            }

        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "UserService.GetAllUsersAsync()", LogTypes.Error);
            return null!;
        }
    }

    public async Task<UserDto> UpdateUserAsync(int userId, UserDto userData)
    {
        try
        {
            var existingUser = await _userRepository.GetUserByIdAsync(userId);
            if (existingUser == null)
            {
                _logger.Log($"User with ID '{userId}' does not exist.", "UserService.UpdateUserAsync()", LogTypes.Info);
                return null!;
            }

            if (!string.IsNullOrWhiteSpace(userData.FirstName))
            {
                existingUser.Firstname = userData.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(userData.LastName))
            {
                existingUser.Lastname = userData.LastName;
            }
            if (!string.IsNullOrWhiteSpace(userData.Email))
            {
                existingUser.Email = userData.Email;
            }
            if (!string.IsNullOrWhiteSpace(userData.PhoneNumber))
            {
                existingUser.Phonenumber = userData.PhoneNumber;
            }

            var updatedUser = await _userRepository.UpdateUserAsync(existingUser);
            return UserDtoFactory.Create(updatedUser);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "UserService.UpdateUserAsync()", LogTypes.Error);
            return null!;
        }
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        try
        {
            var existingUser = await _userRepository.GetUserByIdAsync(userId);
            if (existingUser == null)
            {
                _logger.Log($"User with ID '{userId}' does not exist.", "UserService.DeleteUserAsync()", LogTypes.Info);
                return false;
            }

            var result = await _userRepository.DeleteUserAsync(userId);
            return result;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "UserService.DeleteUserAsync()", LogTypes.Error);
            return false;
        }
    }
    public async Task<bool> ExtendBorrowTimeAsync(int borrowId, DateTime newReturnDate)
    {
        try
        {
            var borrowedBooks = await _borrowedBookRepository.GetBorrowedBooksByUserIdAsync(borrowId);
            if (borrowedBooks == null || !borrowedBooks.Any())
            {
                _logger.Log($"No borrowed books found for user with ID '{borrowId}'.", "BorrowService.ExtendBorrowTimeAsync()", LogTypes.Info);
                return false;
            }

            foreach (var borrowedBook in borrowedBooks)
            {
                borrowedBook.ReturnDate = newReturnDate;
            }

            foreach (var borrowedBook in borrowedBooks)
            {
                var updatedReturnDate = borrowedBook.ReturnDate.AddDays(14);
                await _borrowedBookRepository.UpdateBorrowedBookAsync(borrowedBook.BorrowID, updatedReturnDate);
            }



            return true;
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BorrowService.ExtendBorrowTimeAsync()", LogTypes.Error);
            return false;
        }

    }
    public async Task<IEnumerable<BookDto>> GetAllBooksByCategoryAsync(int categoryId)
    {
        try
        {
            var booksByCategory = await _bookRepository.GetAllBooksByCategoryAsync(categoryId);

            return booksByCategory.Select(book => BookDtoFactory.Create(book));
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "BookService.GetAllBooksByCategoryAsync()", LogTypes.Error);
            return null!;
        }
    }
}
