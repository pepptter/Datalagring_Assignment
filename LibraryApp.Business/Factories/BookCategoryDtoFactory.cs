using LibraryApp.Infrastructure.Entities;
using LibraryApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Factories
{
    public static class BookCategoryDtoFactory
    {
        public static BookCategoryDto Create(BookCategoryEntity bookCategoryEntity)
        {
            return new BookCategoryDto
            {
                BookCategoryID = bookCategoryEntity.BookCategoryID,
                BookID = bookCategoryEntity.BookID,
                CategoryID = bookCategoryEntity.CategoryID
            };
        }
    }
}
