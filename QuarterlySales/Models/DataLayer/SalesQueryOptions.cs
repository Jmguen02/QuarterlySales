using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public class SalesQueryOptions : QueryOptions<Sale>
    {
        public void SortFilter(SalesGridBuilder builder)
        {
            if (builder.IsFilterByEmployee)
            {
                int id = builder.CurrentRoute.EmployeeFilter.ToInt();
                if (id > 0)
                {
                    Where = s => s.Employee.EmployeeId == id;
                }
            }
            else
            {
                OrderBy = s => s.Employee.LastName;
            }
        }
    }
}
