using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lunchBlazor.Server.Migrations
{
    public partial class newDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MppChildForm_JurusanPendidikan_JurusanPendidikanId",
                table: "MppChildForm");

            migrationBuilder.DropForeignKey(
                name: "FK_MppChildForm_Pendidikan_PendidikanId",
                table: "MppChildForm");

            migrationBuilder.DropIndex(
                name: "IX_MppChildForm_JurusanPendidikanId",
                table: "MppChildForm");

            migrationBuilder.DropIndex(
                name: "IX_MppChildForm_PendidikanId",
                table: "MppChildForm");

            migrationBuilder.DropColumn(
                name: "JurusanPendidikanId",
                table: "MppChildForm");

            migrationBuilder.DropColumn(
                name: "PendidikanId",
                table: "MppChildForm");

            migrationBuilder.AlterColumn<string>(
                name: "Usia",
                table: "MppChildForm",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StatusPernikahan",
                table: "MppChildForm",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Jurusan",
                table: "MppChildForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lulusan",
                table: "MppChildForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pengajuan",
                table: "MppChildForm",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jurusan",
                table: "MppChildForm");

            migrationBuilder.DropColumn(
                name: "Lulusan",
                table: "MppChildForm");

            migrationBuilder.DropColumn(
                name: "Pengajuan",
                table: "MppChildForm");

            migrationBuilder.AlterColumn<int>(
                name: "Usia",
                table: "MppChildForm",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "StatusPernikahan",
                table: "MppChildForm",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JurusanPendidikanId",
                table: "MppChildForm",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PendidikanId",
                table: "MppChildForm",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MppChildForm_JurusanPendidikanId",
                table: "MppChildForm",
                column: "JurusanPendidikanId");

            migrationBuilder.CreateIndex(
                name: "IX_MppChildForm_PendidikanId",
                table: "MppChildForm",
                column: "PendidikanId");

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
    }
}
