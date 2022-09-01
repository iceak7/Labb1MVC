using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Models
{
    public class BookBorrow
    {
        [Key]
        public int BookBorrowId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnLatestDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public bool Returned { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
