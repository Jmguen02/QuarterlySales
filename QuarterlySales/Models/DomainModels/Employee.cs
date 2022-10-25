using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using QuarterlySales.Models.Validation;

namespace QuarterlySales.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter First Name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Required(ErrorMessage = "Please enter Date of Birth.")]
        [PastDate(ErrorMessage = "Birth date must be a valid date that's in the past.")]
        [Remote("CheckEmployee", "Validation", AdditionalFields = "FirstName, LastName")]
        [Display(Name = "Birth Date")]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Please enter a Date of Hire.")]
        [PastDate(ErrorMessage = "Hire date must be a valid date that's in the past.")]
        [GreaterThan("1/1/1995", ErrorMessage = "Date of hire must be after 1/1/1995.")]
        [Display(Name = "Hire Date")]
        public DateTime? DOH { get; set; }

        [GreaterThan(0, ErrorMessage = "Please select a manager.")]
        [Remote("CheckManager", "Validation", AdditionalFields = "FirstName, LastName, DateOfBirth")]
        [Display(Name = "Manager")]
        public int ManagerId { get; set; }
    }
}
