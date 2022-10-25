using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public class GridDTO
    {
        public string SortField { get; set; }
        public string SortDirection { get; set; } = "asc";
    }
}
