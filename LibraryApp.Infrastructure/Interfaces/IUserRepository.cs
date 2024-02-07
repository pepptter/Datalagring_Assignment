using LibraryApp.Infrastructure.Entities;


namespace LibraryApp.Infrastructure.Interfaces
{
    public interface IUserRepository : IRepo<UserEntity>
    {
        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="user">The user entity to add.</param>
        /// <returns>The added user entity.</returns>
        Task<UserEntity> AddUserAsync(UserEntity user);

        /// <summary>
        /// Retrieves all users from the repository.
        /// </summary>
        /// <returns>A collection of all users.</returns>
        Task<IEnumerable<UserEntity>> GetAllUsersAsync();

        /// <summary>
        /// Retrieves a user by their ID from the repository.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>The user entity if found, otherwise null.</returns>
        Task<UserEntity?> GetUserByIdAsync(int userId);

        /// <summary>
        /// Retrieves a user by their email from the repository.
        /// </summary>
        /// <param name="userEmail">The email of the user to retrieve.</param>
        /// <returns>The user entity if found, otherwise null.</returns>
        Task<UserEntity?> GetUserByUserEmailAsync(string userEmail);

        /// <summary>
        /// Updates an existing user in the repository.
        /// </summary>
        /// <param name="user">The user entity to update.</param>
        /// <returns>The updated user entity.</returns>
        Task<UserEntity> UpdateUserAsync(UserEntity user);

        /// <summary>
        /// Deletes a user from the repository.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>True if the user was successfully deleted, otherwise false.</returns>
        Task<bool> DeleteUserAsync(int userId);
    }
}
