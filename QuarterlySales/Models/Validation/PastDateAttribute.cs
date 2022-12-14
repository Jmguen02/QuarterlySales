using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuarterlySales.Models.Validation
{
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime)
            {
                DateTime dateToCheck = (DateTime)value;

                if (dateToCheck < DateTime.Today)
                {
                    return ValidationResult.Success;
                }
            }

            string message = base.ErrorMessage ?? $"{validationContext.DisplayName} must be a valid date in the past.";
            return new ValidationResult(message);
        }
    }
}
