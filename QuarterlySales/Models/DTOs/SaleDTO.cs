using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public class SaleDTO
    {
        public int SaleId { get; set; }
        public double? Amount { get; set; }
        public int? Quarter { get; set; }
        public int? Year { get; set; }
        public int EmployeeId { get; set; }

        public void Load(Sale sales)
        {
            SaleId = sales.SaleId;
            Amount = sales.Amount;
            Quarter = sales.Quarter;
            Year = sales.Year;
            EmployeeId = sales.EmployeeId;
        }
    }
}
