using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public interface IQuarterlySalesUnitOfWork
    {
        Repository<Employee> Employees { get; }

        Repository<Sale> Sales { get; }

        void Save();
    }
}
