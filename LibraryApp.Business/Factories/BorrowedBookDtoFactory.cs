using LibraryApp.Infrastructure.Entities;
using LibraryApp.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Factories
{
    public static class BorrowedBookDtoFactory
    {
        public static BorrowedBookDto Create(BorrowedBookEntity borrowedBookEntity)
        {
            if (borrowedBookEntity == null)
            {
                throw new ArgumentNullException(nameof(borrowedBookEntity));
            }

            return new BorrowedBookDto
            {
                BorrowID = borrowedBookEntity.BorrowID,
                UserID = borrowedBookEntity.UserID,
                BookID = borrowedBookEntity.BookID,
                BorrowDate = borrowedBookEntity.BorrowDate,
                ReturnDate = borrowedBookEntity.ReturnDate
            };
        }

        public static BorrowedBookEntity Create(BorrowedBookDto borrowedBookDto)
        {
            if (borrowedBookDto == null)
            {
                throw new ArgumentNullException(nameof(borrowedBookDto));
            }

            return new BorrowedBookEntity
            {
                BorrowID = borrowedBookDto.BorrowID,
                UserID = borrowedBookDto.UserID,
                BookID = borrowedBookDto.BookID,
                BorrowDate = borrowedBookDto.BorrowDate,
                ReturnDate = borrowedBookDto.ReturnDate
            };
        }
    }
}
