using Microsoft.AspNetCore.Mvc;
using System.Linq;
using QuarterlySales.Models;
using QuarterlySales.Models.Validation;

namespace QuarterlySales.Controllers
{
    public class SaleController : Controller
    {
        private SalesContext context { get; set; }

        public SaleController(SalesContext ctx) => context = ctx;

        public IActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Sale sales)
        {
            string message = Validate.CheckSales(context, sales);
            if (!string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError(nameof(sales.EmployeeId), message);
            }

            if (ModelState.IsValid)
            {
                context.Sales.Add(sales);
                context.SaveChanges();
                TempData["message"] = $"Sales added";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = context.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();
                return View();
            }
        }
    }
}
