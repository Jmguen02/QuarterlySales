using System;
using Microsoft.EntityFrameworkCore;

namespace QuarterlySales.Models
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        { }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Joe",
                    LastName = "Burrow",
                    DOB = new DateTime(1996, 12, 10),
                    DOH = new DateTime(2020, 7, 31),
                    ManagerId = 0
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Ada",
                    LastName = "Lovelace",
                    DOB = new DateTime(1985, 9, 26),
                    DOH = new DateTime(2002, 1, 15),
                    ManagerId = 0
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Ja'marr",
                    LastName = "Chase",
                    DOB = new DateTime(2000, 3, 1),
                    DOH = new DateTime(2021, 6, 2),
                    ManagerId = 1
                }
            );

            modelBuilder.Entity<Sale>().HasData(
                new Sale
                {
                    SaleId = 1,
                    Quarter = 4,
                    Year = 2019,
                    Amount = 23456,
                    EmployeeId = 2
                },
                new Sale
                {
                    SaleId = 2,
                    Quarter = 1,
                    Year = 2020,
                    Amount = 34567,
                    EmployeeId = 2
                },
                new Sale
                {
                    SaleId = 3,
                    Quarter = 4,
                    Year = 2019,
                    Amount = 19876,
                    EmployeeId = 3
                },
                new Sale
                {
                    SaleId = 4,
                    Quarter = 1,
                    Year = 2020,
                    Amount = 31009,
                    EmployeeId = 3
                },
                new Sale
                {
                    SaleId = 5,
                    Quarter = 1,
                    Year = 2001,
                    Amount = 344947,
                    EmployeeId = 1
                },
                new Sale
                {
                    SaleId = 6,
                    Quarter = 1,
                    Year = 2001,
                    Amount = 165447,
                    EmployeeId = 2
                }
            );
        }
    }
}
