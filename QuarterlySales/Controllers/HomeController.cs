using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuarterlySales.Models;

namespace QuarterlySales.Controllers
{
    public class HomeController : Controller
    {
        private QuarterlySalesUnitOfWork data { get; set; }
        public HomeController(SalesContext ctx) => data = new QuarterlySalesUnitOfWork(ctx);

        [HttpGet]
        public ViewResult Index(SalesGridDTO values)
        {
            var builder = new SalesGridBuilder(HttpContext.Session, values, defaultSortField: nameof(Sale.Employee.LastName));

            var options = new SalesQueryOptions
            {
                Includes = "Employee",
                OrderByDirection = builder.CurrentRoute.SortDirection,
            };

            options.SortFilter(builder);

            var vm = new SalesListViewModel
            {
                Sales = data.Sales.List(options),
                Employees = data.Employees.List(new QueryOptions<Employee>
                {
                    OrderBy = e => e.LastName
                }),
                CurrentRoute = builder.CurrentRoute,
                SalesListQuarter = new int[4] { 1, 2, 3, 4 },
                SalesListYear = data.Sales.List(new QueryOptions<Sale>
                {
                    Where = s => s.Year >= 2000
                }).Distinct().ToList(),
            };

            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            var builder = new SalesGridBuilder(HttpContext.Session);

            if (clear)
            {
                builder.ClearFilterSegments();
            }
            else
            {
                var employee = data.Employees.Get(filter[0].ToInt());
                builder.LoadFilterSegments(filter, employee);
            }

            builder.SaveRouteSegments();
            return RedirectToAction("Index", builder.CurrentRoute);
        }
    }
}
