using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Models
{
    public interface IBookBorrowRepository
    {
        IEnumerable<BookBorrow> GetAllBookBorrows();
        IEnumerable<BookBorrow> GetBookBorrowsByCustomer(int customerId);
        IEnumerable<BookBorrow> GetBookBorrowsByBook(int bookId);
        bool ReturnABook(int bookBorrowId);
        BookBorrow BorrowABook(BookBorrow bookBorrow);
    }
}
