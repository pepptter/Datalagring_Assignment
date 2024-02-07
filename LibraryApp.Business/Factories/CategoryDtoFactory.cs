using LibraryApp.Infrastructure.Entities;
using LibraryApp.Shared.Dtos;
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
            return new CategoryDto
            {
                CategoryID = categoryEntity.CategoryID,
                Name = categoryEntity.Name
            };
        }
    }
}
