using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class RemovedStatusTitleFieldDromTransactionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusTitle",
                table: "Transactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusTitle",
                table: "Transactions",
                type: "text",
                nullable: true);
        }
    }
}
