using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToeGame.Migrations
{
    /// <inheritdoc />
    public partial class AddNumWinsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumWins",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumWins",
                table: "Users");
        }
    }
}
