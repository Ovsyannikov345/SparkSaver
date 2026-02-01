using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SparkSaver.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserIdToChatId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelegramUserId",
                table: "Links",
                newName: "ChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Links",
                newName: "TelegramUserId");
        }
    }
}
