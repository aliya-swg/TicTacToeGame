using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToeGame.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "NumWins", "Password" },
                values: new object[] { 100, "admin@example.com", "Admin", 0, "EF92B778BAFE771E89245B89ECBC08A44A4E166C06659911881F383D4473E94F" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100);
        }
    }
}
