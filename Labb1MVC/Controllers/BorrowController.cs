using Labb1MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Controllers
{
    public class BorrowController : Controller
    {
        private readonly IBookBorrowRepository _bookBorrowRepository;

        public BorrowController(IBookBorrowRepository bookBorrowRepository)
        {
            _bookBorrowRepository = bookBorrowRepository;
        }
        public IActionResult Index(string sortOrder, string borrowStatus, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentBorrowStatus"] = borrowStatus;

            var borrows = _bookBorrowRepository.GetAllBookBorrows();

            switch (borrowStatus)
            {
                case "returned":
                    borrows = borrows.Where(b => b.Returned == true);
                    ViewData["BorrowStatus"] = "returned";
                    break;
                case "notReturned":
                    borrows = borrows.Where(b => b.Returned == false);
                    ViewData["BorrowStatus"] = "notReturned";
                    break;
                default:
                    ViewData["BorrowStatus"] = "all";
                    break;
            }

            switch (sortOrder)
            {
                case "nameAsc":
                    borrows = borrows.OrderBy(b => b.Customer.Name);
                    ViewData["BorrowSortOrder"] = "nameAsc";
                    break;
                case "nameDesc":
                    borrows = borrows.OrderByDescending(b => b.Customer.Name);
                    ViewData["BorrowSortOrder"] = "nameDesc";
                    break;
                case "bookTitleAsc":
                    borrows = borrows.OrderBy(b => b.Book.Title);
                    ViewData["BorrowSortOrder"] = "bookTitleAsc";
                    break;
                case "bookTitleDesc":
                    borrows = borrows.OrderByDescending(b => b.Book.Title);
                    ViewData["BorrowSortOrder"] = "bookTitleDesc";
                    break;
                case "borrowDateAsc":
                    borrows = borrows.OrderBy(b => b.BorrowDate);
                    ViewData["BorrowSortOrder"] = "borrowDateAsc";
                    break;
                case "borrowDateDesc":
                    borrows = borrows.OrderByDescending(b => b.BorrowDate);
                    ViewData["BorrowSortOrder"] = "borrowDateDesc";
                    break;

                default:
                    borrows = borrows.OrderBy(b => b.BorrowDate);
                    ViewData["BorrowSortOrder"] = "borrowDateAsc";
                    break;
            }

            int pageSize = 5;

            return View(PaginatedList<BookBorrow>.Create(borrows, pageNumber ?? 1, pageSize));
        }

        public IActionResult ReturnABook(int id, string from)
        {
            if (_bookBorrowRepository.ReturnABook(id))
            {
                if(from == "customerDetail")
                {
                    var bookBorrow = _bookBorrowRepository.GetBookBorrowById(id);
                    return RedirectToAction("Detail", "Customers", new { id = bookBorrow.CustomerId, mes = "Succesfully returned a book" });
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (from == "customerDetail")
                {
                    var bookBorrow = _bookBorrowRepository.GetBookBorrowById(id);
                    return RedirectToAction("Detail", "Customers", new { id = bookBorrow.CustomerId, mes = "Failed to return a book. Try again.", mesStatus = "failed" });
                }
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult NewBorrow()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewBorrow([Bind("ReturnLatestDate, CustomerId, BookId")]BookBorrow bookBorrow, string from)
        {
            if (ModelState.IsValid)
            {
                _bookBorrowRepository.BorrowABook(bookBorrow);

                if (from == "customerDetail")
                {
                    return RedirectToAction("Detail", "Customers", new { id = bookBorrow.CustomerId, mes = "Succesfully borrowed a book" });
                }
                return RedirectToAction(nameof(Index));

            }
            if (from == "customerDetail")
            {
                return RedirectToAction("Detail", "Customers", new { id = bookBorrow.CustomerId, mes = "Failed to borrow a book. Check if the date is correct and the book is in stock.", mesStatus="failed" });
            }
            return View(bookBorrow);


        }
    }
}
