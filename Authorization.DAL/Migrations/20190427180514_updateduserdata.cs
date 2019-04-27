using Microsoft.EntityFrameworkCore.Migrations;

namespace Authorization.DAL.Migrations
{
    public partial class updateduserdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "9PsbZovEoCkMiksUuLhLWYjwMSpUKLFbKw2u8dO/9Wg=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "password1");
        }
    }
}
