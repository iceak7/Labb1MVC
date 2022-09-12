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
        public IActionResult Index(string sortOrder, string borrowStatus)
        {

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


            return View(borrows);
        }

        public IActionResult ReturnABook(int id)
        {
            if (_bookBorrowRepository.ReturnABook(id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
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
        public IActionResult NewBorrow([Bind("ReturnLatestDate, CustomerId, BookId")]BookBorrow bookBorrow)
        {
            if (ModelState.IsValid)
            {
                _bookBorrowRepository.BorrowABook(bookBorrow);
                return RedirectToAction(nameof(Index));

            }
            return View(bookBorrow);


        }
    }
}
