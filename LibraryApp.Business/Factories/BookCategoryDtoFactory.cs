using LibraryApp.Infrastructure.Entities;
using LibraryApp.Business.Dtos;
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
            if (bookCategoryEntity == null)
            {
                throw new ArgumentNullException(nameof(bookCategoryEntity));
            }

            return new BookCategoryDto
            {
                BookCategoryID = bookCategoryEntity.BookCategoryID,
                BookID = bookCategoryEntity.BookID,
                CategoryID = bookCategoryEntity.CategoryID
            };
        }

        public static BookCategoryEntity Create(BookCategoryDto bookCategoryDto)
        {
            if (bookCategoryDto == null)
            {
                throw new ArgumentNullException(nameof(bookCategoryDto));
            }

            return new BookCategoryEntity
            {
                BookCategoryID = bookCategoryDto.BookCategoryID,
                BookID = bookCategoryDto.BookID,
                CategoryID = bookCategoryDto.CategoryID
            };
        }
    }
}
