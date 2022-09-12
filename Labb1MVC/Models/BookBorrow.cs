using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Labb1MVC.Validation;

namespace Labb1MVC.Models
{
    public class BookBorrow
    {
        [Key]
        public int BookBorrowId { get; set; }
        public DateTime BorrowDate { get; set; }

        [Required(ErrorMessage = "Please enter the return date")]
        [DataType(DataType.DateTime)]
        [DateValidation]
        public DateTime? ReturnLatestDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public bool Returned { get; set; }

        [Required(ErrorMessage = "Please enter the customer")]
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }
        [BindNever]
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Please enter the book")]
        [Display(Name = "Book Id")]
        public int? BookId { get; set; }
        [BindNever]
        public Book Book { get; set; }

    }
}
