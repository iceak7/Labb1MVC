using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter your first name!")]
        [Display(Name = "Full Name")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your telephone number")]
        [Display(Name = "Telephone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNr { get; set; }


        [Required(ErrorMessage = "Please enter your city")]
        [Display(Name = "City")]
        [StringLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [Display(Name = "Street Address")]
        [StringLength(80)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your zipcode")]
        [Display(Name = "Zip Code")]
        [StringLength(5, MinimumLength = 5)]
        public string ZipCode { get; set; }
        [BindNever]
        public ICollection<BookBorrow> BookBorrows { get; set; }
    }
}
