using Microsoft.EntityFrameworkCore.Migrations;

namespace Authorization.DAL.Migrations
{
    public partial class addedseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "Password", "Username" },
                values: new object[] { 1, "Zura", "password1", "zura1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
