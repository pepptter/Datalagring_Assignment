using LibraryApp.Business.Dtos;
using LibraryApp.Business.Interfaces;
using LibraryApp.Business.Services;
using System;
using System.Runtime.CompilerServices;

namespace LibraryApp.ConsoleUI.Services
{
    public class BookServiceUI(IBookService bookService, ICategoryService categoryService)
    {
        private readonly IBookService _bookService = bookService;
        private readonly ICategoryService _categoryService = categoryService;

        public async Task ManageBooksAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Book Services Menu");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Update a book");
                Console.WriteLine("3. Delete a book");
                Console.WriteLine("4. Get a book by ID");
                Console.WriteLine("5. Get all books");
                Console.WriteLine("6. Find books by author");
                Console.WriteLine("7. Find books by title");
                Console.WriteLine("8. Find books by category");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        await AddBookAsync();
                        break;
                    case "2":
                        await UpdateBookAsync();
                        break;
                    case "3":
                        await DeleteBookAsync();
                        break;
                    case "4":
                        await GetBookWithCategoryByIdAsync();
                        break;
                    case "5":
                        await GetAllBooksAsync();
                        break;
                    case "6":
                        await FindBooksByAuthorAsync();
                        break;
                    case "7":
                        await FindBooksByTitleAsync();
                        break;
                    case "8":
                        await FindBooksByCategoryAsync();
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private async Task AddBookAsync()
        {
            Console.WriteLine("Enter book details:");
            Console.Write("Title: ");
            string title = Console.ReadLine()!;
            Console.Write("Author: ");
            string author = Console.ReadLine()!;
            Console.Write("Category: ");
            string categoryName = Console.ReadLine()!;
            Console.Write("Published Year: ");
            int publishedYear;
            while (!int.TryParse(Console.ReadLine(), out publishedYear))
            {
                Console.WriteLine("Invalid input, please enter a valid year.");
                Console.Write("Published Year: ");
            }
            var category = await _categoryService.AddCategoryAsync(categoryName);

            var bookDto = new BookDto { Title = title, Author = author, CategoryName = category.Name, Published_Year = publishedYear };
            await _bookService.AddBookAsync(bookDto);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private async Task UpdateBookAsync()
        {
            Console.Write("Enter the ID of the book you want to update: ");
            int bookId;
            while (!int.TryParse(Console.ReadLine(), out bookId))
            {
                Console.WriteLine("Invalid input, please enter a valid book ID.");
                Console.Write("Enter the ID of the book you want to update: ");
            }

            Console.WriteLine("Enter updated book details:");
            Console.Write("Title (leave blank to keep current): ");
            string title = Console.ReadLine()!;
            Console.Write("Author (leave blank to keep current): ");
            string author = Console.ReadLine()!;
            Console.Write("Category (leave blank to keep current): ");
            string category = Console.ReadLine()!;
            Console.Write("Published Year (leave blank to keep current): ");
            string publishedYearInput = Console.ReadLine()!;

            var existingBook = await _bookService.GetBookByIdAsync(bookId);
            if (existingBook == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }
            var updatedBook = new BookDto
            {
                BookID = bookId,
                Title = string.IsNullOrEmpty(title) ? existingBook.Title : title,
                Author = string.IsNullOrEmpty(author) ? existingBook.Author : author,
                CategoryName = string.IsNullOrEmpty(category) ? existingBook.CategoryName : category
            };

            if (!string.IsNullOrWhiteSpace(publishedYearInput))
            {
                int publishedYear;
                while (!int.TryParse(publishedYearInput, out publishedYear) || publishedYear <= 0)
                {
                    Console.WriteLine("Invalid input, please enter a valid year.");
                    Console.Write("Published Year: ");
                    publishedYearInput = Console.ReadLine()!;
                }
                updatedBook.Published_Year = publishedYear;
            }

            await _bookService.UpdateBookAsync(bookId, updatedBook);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }






        private async Task DeleteBookAsync()
        {
            Console.Write("Enter the ID of the book you want to delete: ");
            int bookId;
            while (!int.TryParse(Console.ReadLine(), out bookId))
            {
                Console.WriteLine("Invalid input, please enter a valid book ID.");
                Console.Write("Enter the ID of the book you want to delete: ");
            }

            await _bookService.DeleteBookAsync(book => book.BookID == bookId);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private async Task GetBookWithCategoryByIdAsync()
        {
            Console.Write("Enter the ID of the book you want to retrieve: ");
            int bookId;
            while (!int.TryParse(Console.ReadLine(), out bookId))
            {
                Console.WriteLine("Invalid input, please enter a valid book ID.");
                Console.Write("Enter the ID of the book you want to retrieve: ");
            }

            var bookDto = await _bookService.GetBookWithCategoriesByIdAsync(bookId);
            if (bookDto != null)
            {
                string categories = string.Join(", ", bookDto.CategoryNames);

                Console.WriteLine($"Book ID: {bookDto.BookID}, Title: {bookDto.Title}, Author: {bookDto.Author}, Published Year: {bookDto.Published_Year}, Categories: {categories}");
            }
            else
            {
                Console.WriteLine($"No book found with ID: {bookId}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }




        private async Task GetAllBooksAsync()
        {
            var books = await _bookService.GetAllBooksAsync();
            foreach (var book in books)
            {
                Console.WriteLine($"Book ID: {book.BookID}, Title: {book.Title}, Author: {book.Author}, Published Year: {book.Published_Year}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private async Task FindBooksByAuthorAsync()
        {
            Console.Write("Enter author name: ");
            string author = Console.ReadLine()!;

            var books = await _bookService.FindBooksByAuthorAsync(author);
            foreach (var book in books)
            {
                Console.WriteLine($"Book ID: {book.BookID}, Title: {book.Title}, Author: {book.Author}, Published Year: {book.Published_Year}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private async Task FindBooksByTitleAsync()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine()!;

            var books = await _bookService.FindBooksByTitleAsync(title);
            foreach (var book in books)
            {
                Console.WriteLine($"Book ID: {book.BookID}, Title: {book.Title}, Author: {book.Author}, Published Year: {book.Published_Year}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private async Task FindBooksByCategoryAsync()
        {
            Console.Write("Enter category name: ");
            string categoryName = Console.ReadLine()!.Trim();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                Console.WriteLine("Category name cannot be empty.");
                return;
            }

            var books = await _bookService.FindBooksByCategoryNameAsync(categoryName);

            if (books != null && books.Any())
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"Book ID: {book.BookID}, Title: {book.Title}, Author: {book.Author}, Published Year: {book.Published_Year}");
                }
            }
            else
            {
                Console.WriteLine("No books found for the specified category.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


    }
}
