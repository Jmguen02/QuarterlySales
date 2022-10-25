using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuarterlySales.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DOH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DOB", "DOH", "FirstName", "LastName", "ManagerId" },
                values: new object[] { 1, new DateTime(1996, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joe", "Burrow", 0 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DOB", "DOH", "FirstName", "LastName", "ManagerId" },
                values: new object[] { 2, new DateTime(1985, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2002, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ada", "Lovelace", 0 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DOB", "DOH", "FirstName", "LastName", "ManagerId" },
                values: new object[] { 3, new DateTime(2000, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ja'marr", "Chase", 1 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "Amount", "EmployeeId", "Quarter", "Year" },
                values: new object[,]
                {
                    { 5, 344947.0, 1, 1, 2001 },
                    { 1, 23456.0, 2, 4, 2019 },
                    { 2, 34567.0, 2, 1, 2020 },
                    { 6, 165447.0, 2, 1, 2001 },
                    { 3, 19876.0, 3, 4, 2019 },
                    { 4, 31009.0, 3, 1, 2020 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
