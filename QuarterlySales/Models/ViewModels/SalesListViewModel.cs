﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public class SalesListViewModel
    {
        public List<Sale> SalesListYear { get; set; }
        public IEnumerable<Sale> Sales { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public int[] SalesListQuarter { get; set; }
    }
}
