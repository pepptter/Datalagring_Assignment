using LibraryApp.Infrastructure.Interfaces;
using LibraryApp.Business.Factories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApp.Business.Dtos;
using LibraryApp.Business.Utils;
using LibraryApp.Business.Interfaces;
using LibraryApp.Infrastructure.Entities;

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
    public async Task<CategoryDto> AddCategoryAsync(object category)
    {
        try
        {
            if (category is CategoryDto categoryDto)
            {
                var addedCategory = await _categoryRepository.AddCategoryAsync(new CategoryEntity { Name = categoryDto.Name });
                return CategoryDtoFactory.Create(addedCategory);
            }
            else if (category is string categoryName)
            {
                var addedCategory = await _categoryRepository.AddCategoryAsync(new CategoryEntity { Name = categoryName });
                return CategoryDtoFactory.Create(addedCategory);
            }
            else
            {
                throw new ArgumentException("Invalid argument type. Expected CategoryDto or string.");
            }
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

