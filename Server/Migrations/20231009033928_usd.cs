using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lunchBlazor.Server.Migrations
{
    public partial class usd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "SumberPemenuhan");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Posisi");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Pendidikan");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "MppForm");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "MppChildForm");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Lokasi");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "JurusanPendidikan");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "JenisPermintaan");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "JenisMpp");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "HistoryMpp");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Golongan");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Divisi");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Departemen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "User",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "SumberPemenuhan",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Status",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Posisi",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Pendidikan",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "MppForm",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "MppChildForm",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Lokasi",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "JurusanPendidikan",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "JenisPermintaan",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "JenisMpp",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "HistoryMpp",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Golongan",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Divisi",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Departemen",
                type: "bit",
                nullable: true);
        }
    }
}
