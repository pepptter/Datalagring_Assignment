using LibraryApp.Infrastructure.Entities;
using LibraryApp.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Factories
{
    public static class CategoryDtoFactory
    {
        public static CategoryDto Create(CategoryEntity categoryEntity)
        {
            if (categoryEntity == null)
            {
                throw new ArgumentNullException(nameof(categoryEntity));
            }

            return new CategoryDto
            {
                CategoryID = categoryEntity.CategoryID,
                Name = categoryEntity.Name
            };
        }

        public static CategoryEntity Create(CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                throw new ArgumentNullException(nameof(categoryDto));
            }

            return new CategoryEntity
            {
                CategoryID = categoryDto.CategoryID,
                Name = categoryDto.Name
            };
        }
    }
}
