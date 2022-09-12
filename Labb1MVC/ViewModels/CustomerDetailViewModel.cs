using Labb1MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.ViewModels
{
    public class CustomerDetailViewModel
    {
        public Customer Customer { get; set; }
        public List<BookBorrow> BookBorrows { get; set; }
        public BookBorrow BookBorrow { get; set; }

    }
}
