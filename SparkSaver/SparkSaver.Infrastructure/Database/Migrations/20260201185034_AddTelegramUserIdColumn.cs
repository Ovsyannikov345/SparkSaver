using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SparkSaver.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddTelegramUserIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TelegramUserId",
                table: "Links",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelegramUserId",
                table: "Links");
        }
    }
}
