using LibraryApp.Infrastructure.Interfaces;
using LibraryApp.Business.Factories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApp.Business.Dtos;
using LibraryApp.Business.Utils;
using LibraryApp.Business.Interfaces;

namespace LibraryApp.Business.Services;

public class CategoryService(ICategoryRepository categoryRepository, ILogger logger) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly ILogger _logger = logger;

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        try
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(CategoryDtoFactory.Create);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryService.GetAllCategoriesAsync()", LogTypes.Error);
            return new List<CategoryDto>();
        }
    }
    public async Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto)
    {
        try
        {
            var categoryEntity = CategoryDtoFactory.Create(categoryDto);
            var addedCategory = await _categoryRepository.AddCategoryAsync(categoryEntity);
            return CategoryDtoFactory.Create(addedCategory);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryService.AddCategoryAsync()", LogTypes.Error);
            return null!;
        }
    }

    public async Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto)
    {
        try
        {
            var categoryToUpdate = await _categoryRepository.GetCategoryByIdAsync(categoryDto.CategoryID);
            if (categoryToUpdate == null)
            {
                _logger.Log($"Category with ID {categoryDto.CategoryID} not found.", "CategoryService.UpdateCategoryAsync()", LogTypes.Warning);
                return null!;
            }

            categoryToUpdate.Name = categoryDto.Name;
            var updatedCategory = await _categoryRepository.UpdateCategoryAsync(categoryToUpdate);
            return CategoryDtoFactory.Create(updatedCategory);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryService.UpdateCategoryAsync()", LogTypes.Error);
            return null!;
        }
    }

    public async Task<IEnumerable<BookDto>> GetBooksByCategoryAsync(int categoryId)
    {
        try
        {
            var books = await _categoryRepository.GetBooksByCategoryAsync(categoryId);
            return books.Select(BookDtoFactory.Create);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryService.GetBooksByCategoryAsync()", LogTypes.Error);
            return new List<BookDto>();
        }
    }

    public async Task<bool> RemoveCategoryAsync(int categoryId)
    {
        try
        {
            return await _categoryRepository.RemoveCategoryAsync(categoryId);
        }
        catch (Exception ex)
        {
            _logger.Log(ex.ToString(), "CategoryService.RemoveCategoryAsync()", LogTypes.Error);
            return false;
        }
    }
}

