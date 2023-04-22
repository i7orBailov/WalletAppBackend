using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class TypoFixAndUserNameSplit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Desctiption",
                table: "Transactions",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Transactions",
                newName: "Desctiption");
        }
    }
}
