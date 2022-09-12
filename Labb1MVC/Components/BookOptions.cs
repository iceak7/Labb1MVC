using Labb1MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Components
{
    public class BookOptions: ViewComponent
    {
            private readonly IBookRepository _bookRepository;

            public BookOptions(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            public IViewComponentResult Invoke()
            {
                var books = _bookRepository.GetAllBooks();
                return View(books);

            }

    }
}
