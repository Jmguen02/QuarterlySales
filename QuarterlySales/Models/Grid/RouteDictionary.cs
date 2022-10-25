using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public class RouteDictionary : Dictionary<string, string>
    {
        public const string Employee = "employee-";
        public string SortField
        {
            get => Get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }

        public string SortDirection
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }

        public void SetSortAndDirection(string fieldName, RouteDictionary current)
        {
            this[nameof(GridDTO.SortField)] = fieldName;

            if (current.SortField.EqualsNoCase(fieldName) && current.SortDirection == "asc")
            {
                this[nameof(GridDTO.SortDirection)] = "desc";
            }
            else
            {
                this[nameof(GridDTO.SortDirection)] = "asc";
            }
        }

        public string EmployeeFilter
        {
            get
            {
                string s = Get(nameof(SalesGridDTO.Employee))?.Replace(Employee, "");
                int index = s?.IndexOf('-') ?? -1;
                return (index == -1) ? s : s.Substring(0, index);
            }
            set => this[nameof(SalesGridDTO.Employee)] = value;
        }

        public void ClearFilters()
        {
            EmployeeFilter = Employee + SalesGridDTO.DefaultFilter;
        }

        private string Get(string key) => Keys.Contains(key) ? this[key] : null;

        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();

            foreach (var key in Keys)
            {
                clone.Add(key, this[key]);
            }

            return clone;
        }
    }
}