using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lunchBlazor.Server.Migrations
{
    public partial class us : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MppForm",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MppForm_UserId",
                table: "MppForm",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MppForm_User_UserId",
                table: "MppForm",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MppForm_User_UserId",
                table: "MppForm");

            migrationBuilder.DropIndex(
                name: "IX_MppForm_UserId",
                table: "MppForm");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MppForm");
        }
    }
}
