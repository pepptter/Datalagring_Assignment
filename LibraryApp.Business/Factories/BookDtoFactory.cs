using LibraryApp.Infrastructure.Entities;
using LibraryApp.Shared.Dtos;
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
            return new BookDto
            {
                BookID = bookEntity.BookID,
                Title = bookEntity.Title,
                Author = bookEntity.Author,
                Published_Year = bookEntity.Published_Year
            };
        }
    }
}
