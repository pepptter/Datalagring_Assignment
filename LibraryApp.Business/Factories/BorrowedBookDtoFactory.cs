using LibraryApp.Infrastructure.Entities;
using LibraryApp.Shared.Dtos;
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
            return new BorrowedBookDto
            {
                BorrowID = borrowedBookEntity.BorrowID,
                UserID = borrowedBookEntity.UserID,
                BookID = borrowedBookEntity.BookID,
                BorrowDate = borrowedBookEntity.BorrowDate,
                ReturnDate = borrowedBookEntity.ReturnDate
            };
        }
    }
}
