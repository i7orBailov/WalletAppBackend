using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class TransaferDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Users",
                schema: "business",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TransactionTypes",
                schema: "business",
                newName: "TransactionTypes");

            migrationBuilder.RenameTable(
                name: "TransactionStatuses",
                schema: "business",
                newName: "TransactionStatuses");

            migrationBuilder.RenameTable(
                name: "Transactions",
                schema: "business",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "Icons",
                schema: "business",
                newName: "Icons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "business");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "business");

            migrationBuilder.RenameTable(
                name: "TransactionTypes",
                newName: "TransactionTypes",
                newSchema: "business");

            migrationBuilder.RenameTable(
                name: "TransactionStatuses",
                newName: "TransactionStatuses",
                newSchema: "business");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transactions",
                newSchema: "business");

            migrationBuilder.RenameTable(
                name: "Icons",
                newName: "Icons",
                newSchema: "business");
        }
    }
}
