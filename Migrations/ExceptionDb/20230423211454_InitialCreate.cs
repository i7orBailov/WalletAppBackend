using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletAppBackend.Migrations.ExceptionDb
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Exception");

            migrationBuilder.CreateTable(
                name: "ExceptionsJournal",
                schema: "Exception",
                columns: table => new
                {
                    EventId = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    QueryParams = table.Column<string>(type: "text", nullable: true),
                    BodyParams = table.Column<string>(type: "text", nullable: true),
                    StackTrace = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionsJournal", x => x.EventId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExceptionsJournal",
                schema: "Exception");
        }
    }
}
