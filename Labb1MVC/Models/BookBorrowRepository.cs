using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Models
{
    public class BookBorrowRepository : IBookBorrowRepository
    {
        private readonly AppDbContext _appDbContext;
        public BookBorrowRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public BookBorrow BorrowABook(BookBorrow bookBorrow)
        {


            if(_appDbContext.Books.Any(b=>b.BookId==bookBorrow.BookId) & _appDbContext.Customers.Any(c => c.CustomerId == bookBorrow.CustomerId))
            {
                bookBorrow.BorrowDate = DateTime.Now;
                bookBorrow.Returned = false;

                var book = _appDbContext.Books.First(b => b.BookId == bookBorrow.BookId);
                book.NumberOfBooksInStock--;

                var createdBookBorrow = _appDbContext.BookBorrows.Add(bookBorrow);
                _appDbContext.SaveChanges();
                return createdBookBorrow.Entity;
            }
            return null;


        }

        public IEnumerable<BookBorrow> GetAllBookBorrows()
        {
            var borrows = _appDbContext.BookBorrows.Include(b => b.Customer).Include(b=>b.Book);

            return borrows.ToList();
        }

        public IEnumerable<BookBorrow> GetBookBorrowsByBook(int bookId)
        {
            var borrows = _appDbContext.BookBorrows.Where(b=>b.BookId==bookId).Include(bo => bo.Customer);

            return borrows.ToList();

        }

        public IEnumerable<BookBorrow> GetBookBorrowsByCustomer(int customerId)
        {
            var borrows = _appDbContext.BookBorrows.Where(b => b.CustomerId == customerId).Include(bo => bo.Book);


            return borrows.ToList();

        }

        public bool ReturnABook(int bookBorrowId)
        {
            var bookBorrowToReturn = _appDbContext.BookBorrows.FirstOrDefault(b => b.BookBorrowId == bookBorrowId);

            if (bookBorrowToReturn != null)
            {
                bookBorrowToReturn.Returned = true;
                bookBorrowToReturn.ReturnedDate = DateTime.Now;

                var bookToReturn = _appDbContext.Books.First(b => b.BookId == bookBorrowToReturn.BookId);
                bookToReturn.NumberOfBooksInStock++;

                _appDbContext.SaveChanges();
                return true;
            }

            return false;
        }



    }
}
