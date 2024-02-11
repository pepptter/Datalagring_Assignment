using LibraryApp.Business.Dtos;

namespace LibraryApp.Business.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="userData">Data of the user to be registered.</param>
        /// <returns>The newly registered user.</returns>
        Task<UserDto> RegisterUserAsync(UserDto userData);

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID, or null if not found.</returns>
        Task<UserDto> GetUserByIdAsync(int userId);

        /// <summary>
        /// Retrieves all users in the system.
        /// </summary>
        /// <returns>A collection of all users in the system.</returns>
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        /// <summary>
        /// Updates an existing user in the system.
        /// </summary>
        /// <param name="userId">The ID of the user to be updated.</param>
        /// <param name="userData">New data for the user.</param>
        /// <returns>The updated user.</returns>
        Task<UserDto> UpdateUserAsync(int userId, UserDto userData);

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>True if the deletion was successful, otherwise false.</returns>
        Task<bool> DeleteUserAsync(int userId);

        /// <summary>
        /// Extends the return time for borrowed books of a user.
        /// </summary>
        /// <param name="borrowId">The ID of the borrowed book.</param>
        /// <param name="newReturnDate">The new return date for the borrowed books.</param>
        /// <returns>True if the extension was successful, otherwise false.</returns>
        Task<bool> ExtendBorrowTimeAsync(int borrowId, DateTime newReturnDate);

        /// <summary>
        /// Retrieves all books belonging to a specific category.
        /// </summary>
        /// <param name="categoryId">The ID of the category.</param>
        /// <returns>A collection of books belonging to the specified category.</returns>
        Task<IEnumerable<BookDto>> GetAllBooksByCategoryAsync(int categoryId);
    }
}