using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPasswordSaltFieldInUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Convert existing data in the PasswordSalt column to bytea
            migrationBuilder.Sql("UPDATE \"Users\" SET \"PasswordSalt\" = encode(convert_to(\"PasswordSalt\", 'UTF8'), 'hex')");

            // Change the data type of the PasswordSalt column to bytea
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "bytea",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea");
        }
    }
}
