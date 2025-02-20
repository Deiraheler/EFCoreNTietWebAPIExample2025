using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAD302Week3Lab12025CL.S00243021.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomerData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Address", "CreditRating", "Name" },
                values: new object[] { 1, "8 Johnstown Road, Cork", 200f, "Patricia McKenna" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
