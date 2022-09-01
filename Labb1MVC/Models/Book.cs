using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int TotalNumberOfBooks { get; set; }

        public int NumberOfBooksInStock { get; set; }

        public ICollection<BookBorrow> BookBorrows { get; set; }
    }
}
