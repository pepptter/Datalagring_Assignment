using LibraryApp.Business.Dtos;
using LibraryApp.Business.Interfaces;
using LibraryApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.ConsoleUI.Services;

public class CategoryServicesUI(ICategoryService categoryService, ICategoryRepository categoryRepository, IBookCategoryRepository bookCategoryRepository)
{
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IBookCategoryRepository _bookCategoryRepository = bookCategoryRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task ManageCategoriesAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Manage Categories");
            Console.WriteLine("1. Add a category");
            Console.WriteLine("2. View all categories");
            Console.WriteLine("3. Update a category");
            Console.WriteLine("4. Delete a category");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    await AddCategoryAsync();
                    break;
                case "2":
                    await GetAllCategoriesAsync();
                    break;
                case "3":
                    await UpdateCategoryAsync();
                    break;
                case "4":
                    await DeleteCategoryAsync();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }

    }
    private async Task AddCategoryAsync()
    {
        Console.WriteLine("Enter category name:");
        string categoryName = Console.ReadLine()!;

        var existingCategory = await _categoryService.GetCategoryByNameAsync(categoryName);
        if (existingCategory != null)
        {
            Console.WriteLine($"Category '{categoryName}' already exists.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        var result = await _categoryService.AddCategoryAsync(new CategoryDto { Name = categoryName });
        if (result != null)
        {
            Console.WriteLine("Category added successfully.");
        }
        else
        {
            Console.WriteLine("Failed to add category.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task UpdateCategoryAsync()
    {
        Console.WriteLine("Enter the ID of the category you want to update:");
        if (!int.TryParse(Console.ReadLine(), out int categoryId))
        {
            Console.WriteLine("Invalid input for category ID.");
            return;
        }

        Console.WriteLine("Enter the new name for the category:");
        string categoryName = Console.ReadLine()!;

        var existingCategory = await _categoryService.GetCategoryByNameAsync(categoryName);
        if (existingCategory != null && existingCategory.CategoryID != categoryId)
        {
            Console.WriteLine($"Category '{categoryName}' already exists.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        var result = await _categoryService.UpdateCategoryAsync(new CategoryDto { CategoryID = categoryId, Name = categoryName });
        if (result != null)
        {
            Console.WriteLine("Category updated successfully.");
        }
        else
        {
            Console.WriteLine("Failed to update category or category not found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task DeleteCategoryAsync()
    {
        Console.WriteLine("Enter the ID of the category you want to delete:");
        if (!int.TryParse(Console.ReadLine(), out int categoryId))
        {
            Console.WriteLine("Invalid input for category ID.");
            return;
        }

        var result = await _categoryService.RemoveCategoryAsync(categoryId);
        if (result)
        {
            Console.WriteLine("Category deleted successfully.");
        }
        else
        {
            Console.WriteLine("Failed to delete category or category not found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task GetAllCategoriesAsync()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        foreach (var category in categories)
        {
            Console.WriteLine($"Category ID: {category.CategoryID}, Name: {category.Name}");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}

