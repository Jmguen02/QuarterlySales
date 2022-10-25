using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace QuarterlySales.Models
{
    public class SalesGridBuilder : GridBuilder
    {
        public SalesGridBuilder(ISession sess) : base(sess) { }
        public SalesGridBuilder(ISession sess, SalesGridDTO values, string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isInitial = values.Employee.IndexOf(RouteDictionary.Employee) == -1;
            routes.EmployeeFilter = (isInitial) ? RouteDictionary.Employee + values.Employee : values.Employee;
        }

        public void LoadFilterSegments(string[] filter, Employee employee)
        {
            if (employee == null)
            {
                routes.EmployeeFilter = RouteDictionary.Employee + filter[0];
            }
            else
            {
                routes.EmployeeFilter = RouteDictionary.Employee + filter[0] + "-" + employee.FullName.Slug();
            }
        }

        public void ClearFilterSegments() => routes.ClearFilters();

        string def = SalesGridDTO.DefaultFilter;
        public bool IsFilterByEmployee => routes.EmployeeFilter != def;
    }
}
