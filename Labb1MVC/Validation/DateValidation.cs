using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1MVC.Validation
{
    public class DateValidation : ValidationAttribute
    {
        public DateValidation() 
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dt = (DateTime)value;
                if (0 < dt.CompareTo(DateTime.Now.AddDays(1)))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult(ErrorMessage ?? "Make sure your date is at least 24h from now");
            }
            else
            {
                return new ValidationResult(ErrorMessage ?? "Invalid date");
            }

        }
    }
}
