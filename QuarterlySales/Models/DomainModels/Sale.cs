using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using QuarterlySales.Models.Validation;

namespace QuarterlySales.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        [Required(ErrorMessage = "Please enter a Quarter.")]
        [Range(1, 4, ErrorMessage = "Please enter a Quarter 1 through 4.")]
        public int? Quarter { get; set; }

        [Required(ErrorMessage = "Please enter a Year.")]
        [GreaterThan(2000, ErrorMessage = "Please enter a Year after 2000.")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter a sale Amount.")]
        [GreaterThan(0.0, ErrorMessage = "Please enter a sale Amount over $0.")]
        public double? Amount { get; set; }

        [GreaterThan(0, ErrorMessage = "Please select an employee.")]
        [Remote("CheckSales", "Validation", AdditionalFields = "Quarter, Year")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}