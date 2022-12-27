using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class FluenAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Password", "Status", "UpdateDate", "Username" },
                values: new object[] { 1, new DateTime(2022, 9, 1, 10, 23, 3, 753, DateTimeKind.Local).AddTicks(9804), null, "1234", 1, null, "bayzin" });
        }
    }
}
