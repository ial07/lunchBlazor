using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lunchBlazor.Server.Migrations
{
    public partial class initDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departemen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departemen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devisi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devisi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Golongan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Golongan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoryMpp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MppId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryMpp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JenisMpp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisMpp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JenisPermintaan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisPermintaan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokasi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokasi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posisi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posisi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SumberPemenuhan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SumberPemenuhan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MppForm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoMpp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrpPemohon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaPemohon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriLokasiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DevisiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JenisMppId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TahunMpp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsApprovalADH = table.Column<bool>(type: "bit", nullable: true),
                    IsApprovalBM = table.Column<bool>(type: "bit", nullable: true),
                    IsApprovalHCBP = table.Column<bool>(type: "bit", nullable: true),
                    IsApprovalDivHead = table.Column<bool>(type: "bit", nullable: true),
                    IsApprovalPICA1B1 = table.Column<bool>(type: "bit", nullable: true),
                    IsApprovalOPCC = table.Column<bool>(type: "bit", nullable: true),
                    IsApprovalGMHC = table.Column<bool>(type: "bit", nullable: true),
                    IsApprovalDirectorHC = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDraft = table.Column<bool>(type: "bit", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MppForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MppForm_Devisi_DevisiId",
                        column: x => x.DevisiId,
                        principalTable: "Devisi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MppForm_JenisMpp_JenisMppId",
                        column: x => x.JenisMppId,
                        principalTable: "JenisMpp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MppForm_Lokasi_KategoriLokasiId",
                        column: x => x.KategoriLokasiId,
                        principalTable: "Lokasi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MppForm_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MppChildForm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MppFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosisiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartemenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GolonganId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TargetPemenuhan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DevisiTujuanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LokasiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DevisiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JumlahMp = table.Column<int>(type: "int", nullable: true),
                    JumlahPermintaan = table.Column<int>(type: "int", nullable: true),
                    AlasanPengajuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JenisPermintaanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SumberPemenuhanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DetailSumberPemenuhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosisiManPower = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailPekerjaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lulusan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaLulusan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usia = table.Column<int>(type: "int", nullable: true),
                    StatusPernikahan = table.Column<bool>(type: "bit", nullable: true),
                    StatusPegawai = table.Column<bool>(type: "bit", nullable: true),
                    PengalamanKerja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeahlianKhusus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersyaratanFisik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatatanTambahan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MppChildForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MppChildForm_Departemen_DepartemenId",
                        column: x => x.DepartemenId,
                        principalTable: "Departemen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MppChildForm_Devisi_DevisiId",
                        column: x => x.DevisiId,
                        principalTable: "Devisi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MppChildForm_Devisi_DevisiTujuanId",
                        column: x => x.DevisiTujuanId,
                        principalTable: "Devisi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MppChildForm_Golongan_GolonganId",
                        column: x => x.GolonganId,
                        principalTable: "Golongan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MppChildForm_JenisPermintaan_JenisPermintaanId",
                        column: x => x.JenisPermintaanId,
                        principalTable: "JenisPermintaan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MppChildForm_Lokasi_LokasiId",
                        column: x => x.LokasiId,
                        principalTable: "Lokasi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MppChildForm_MppForm_MppFormId",
                        column: x => x.MppFormId,
                        principalTable: "MppForm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MppChildForm_Posisi_PosisiId",
                        column: x => x.PosisiId,
                        principalTable: "Posisi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MppChildForm_SumberPemenuhan_SumberPemenuhanId",
                        column: x => x.SumberPemenuhanId,
                        principalTable: "SumberPemenuhan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MppChildForm_DepartemenId",
                table: "MppChildForm",
                column: "DepartemenId");

            migrationBuilder.CreateIndex(
                name: "IX_MppChildForm_DevisiId",
                table: "MppChildForm",
                column: "DevisiId");

            migrationBuilder.CreateIndex(
                name: "IX_MppChildForm_DevisiTujuanId",
                table: "MppChildForm",
                column: "DevisiTujuanId");

            migrationBuilder.CreateIndex(
                name: "IX_MppChildForm_GolonganId",
                table: "MppChildForm",
                column: "GolonganId");

            migrationBuilder.CreateIndex(
                name: "IX_MppChildForm_JenisPermintaanId",
                table: "MppChildForm",
                column: "JenisPermintaanId");

            migrationBuilder.CreateIndex(
                name: "IX_MppChildForm_LokasiId",
                table: "MppChildForm",
                column: "LokasiId");

            migrationBuilder.CreateIndex(
                name: "IX_MppChildForm_MppFormId",
                table: "MppChildForm",
                column: "MppFormId");

            migrationBuilder.CreateIndex(
                name: "IX_MppChildForm_PosisiId",
                table: "MppChildForm",
                column: "PosisiId");

            migrationBuilder.CreateIndex(
                name: "IX_MppChildForm_SumberPemenuhanId",
                table: "MppChildForm",
                column: "SumberPemenuhanId");

            migrationBuilder.CreateIndex(
                name: "IX_MppForm_DevisiId",
                table: "MppForm",
                column: "DevisiId");

            migrationBuilder.CreateIndex(
                name: "IX_MppForm_JenisMppId",
                table: "MppForm",
                column: "JenisMppId");

            migrationBuilder.CreateIndex(
                name: "IX_MppForm_KategoriLokasiId",
                table: "MppForm",
                column: "KategoriLokasiId");

            migrationBuilder.CreateIndex(
                name: "IX_MppForm_StatusId",
                table: "MppForm",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryMpp");

            migrationBuilder.DropTable(
                name: "MppChildForm");

            migrationBuilder.DropTable(
                name: "Departemen");

            migrationBuilder.DropTable(
                name: "Golongan");

            migrationBuilder.DropTable(
                name: "JenisPermintaan");

            migrationBuilder.DropTable(
                name: "MppForm");

            migrationBuilder.DropTable(
                name: "Posisi");

            migrationBuilder.DropTable(
                name: "SumberPemenuhan");

            migrationBuilder.DropTable(
                name: "Devisi");

            migrationBuilder.DropTable(
                name: "JenisMpp");

            migrationBuilder.DropTable(
                name: "Lokasi");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
