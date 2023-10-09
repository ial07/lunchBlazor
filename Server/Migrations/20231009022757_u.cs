using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lunchBlazor.Server.Migrations
{
    public partial class u : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JenisPengajuan",
                table: "MppForm",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JenisPengajuan",
                table: "MppForm");
        }
    }
}
