using Labb1MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.ViewModels
{
    public class NewBorrowViewModel
    {
        public BookBorrow BookBorrow { get; set; }

        public List<Book> Books { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
