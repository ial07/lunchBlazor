using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lunchBlazor.Server.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MppChildForm_Divisi_DevisiId",
                table: "MppChildForm");

            migrationBuilder.DropColumn(
                name: "JenisKelamin",
                table: "MppChildForm");

            migrationBuilder.RenameColumn(
                name: "NamaLulusan",
                table: "MppChildForm",
                newName: "NamaLokasi");

            migrationBuilder.RenameColumn(
                name: "Lulusan",
                table: "MppChildForm",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "DevisiId",
                table: "MppChildForm",
                newName: "PendidikanId");

            migrationBuilder.RenameIndex(
                name: "IX_MppChildForm_DevisiId",
                table: "MppChildForm",
                newName: "IX_MppChildForm_PendidikanId");

            migrationBuilder.AlterColumn<string>(
                name: "StatusPegawai",
                table: "MppChildForm",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JurusanPendidikanId",
                table: "MppChildForm",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JurusanPendidikan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JurusanPendidikan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pendidikan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pendidikan", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MppChildForm_JurusanPendidikanId",
                table: "MppChildForm",
                column: "JurusanPendidikanId");

            migrationBuilder.AddForeignKey(
                name: "FK_MppChildForm_JurusanPendidikan_JurusanPendidikanId",
                table: "MppChildForm",
                column: "JurusanPendidikanId",
                principalTable: "JurusanPendidikan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MppChildForm_Pendidikan_PendidikanId",
                table: "MppChildForm",
                column: "PendidikanId",
                principalTable: "Pendidikan",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MppChildForm_JurusanPendidikan_JurusanPendidikanId",
                table: "MppChildForm");

            migrationBuilder.DropForeignKey(
                name: "FK_MppChildForm_Pendidikan_PendidikanId",
                table: "MppChildForm");

            migrationBuilder.DropTable(
                name: "JurusanPendidikan");

            migrationBuilder.DropTable(
                name: "Pendidikan");

            migrationBuilder.DropIndex(
                name: "IX_MppChildForm_JurusanPendidikanId",
                table: "MppChildForm");

            migrationBuilder.DropColumn(
                name: "JurusanPendidikanId",
                table: "MppChildForm");

            migrationBuilder.RenameColumn(
                name: "PendidikanId",
                table: "MppChildForm",
                newName: "DevisiId");

            migrationBuilder.RenameColumn(
                name: "NamaLokasi",
                table: "MppChildForm",
                newName: "NamaLulusan");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "MppChildForm",
                newName: "Lulusan");

            migrationBuilder.RenameIndex(
                name: "IX_MppChildForm_PendidikanId",
                table: "MppChildForm",
                newName: "IX_MppChildForm_DevisiId");

            migrationBuilder.AlterColumn<bool>(
                name: "StatusPegawai",
                table: "MppChildForm",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JenisKelamin",
                table: "MppChildForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MppChildForm_Divisi_DevisiId",
                table: "MppChildForm",
                column: "DevisiId",
                principalTable: "Divisi",
                principalColumn: "Id");
        }
    }
}
