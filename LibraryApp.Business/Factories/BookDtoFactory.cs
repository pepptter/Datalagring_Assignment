using LibraryApp.Infrastructure.Entities;
using LibraryApp.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Factories
{
    public static class BookDtoFactory
    {
        public static BookDto Create(BookEntity bookEntity)
        {
            if (bookEntity == null)
            {
                throw new ArgumentNullException(nameof(bookEntity));
            }

            return new BookDto
            {
                BookID = bookEntity.BookID,
                Title = bookEntity.Title,
                Author = bookEntity.Author,
                Published_Year = bookEntity.Published_Year
            };
        }

        public static BookEntity Create(BookDto bookDto)
        {
            if (bookDto == null)
            {
                throw new ArgumentNullException(nameof(bookDto));
            }

            return new BookEntity
            {
                BookID = bookDto.BookID,
                Title = bookDto.Title,
                Author = bookDto.Author,
                Published_Year = bookDto.Published_Year
            };
        }
    }
}
