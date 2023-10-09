﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lunchBlazor.Server.Data;

#nullable disable

namespace lunchBlazor.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("lunchBlazor.Shared.Models.Departemen", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Departemen");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.Divisi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Divisi");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.Golongan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Golongan");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.HistoryMpp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MppId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("HistoryMpp");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.JenisMpp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("JenisMpp");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.JenisPermintaan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("JenisPermintaan");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.JurusanPendidikan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("JurusanPendidikan");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.Lokasi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Lokasi");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.MppChildForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlasanPengajuan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CatatanTambahan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DepartemenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DetailPekerjaan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DetailSumberPemenuhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DevisiTujuanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GolonganId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("JenisPermintaanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("JumlahMp")
                        .HasColumnType("int");

                    b.Property<int?>("JumlahPermintaan")
                        .HasColumnType("int");

                    b.Property<string>("Jurusan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeahlianKhusus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LokasiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Lulusan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MppFormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NamaLokasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pengajuan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PengalamanKerja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersyaratanFisik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PosisiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PosisiManPower")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusPegawai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusPernikahan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SumberPemenuhanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("TargetPemenuhan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Usia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartemenId");

                    b.HasIndex("DevisiTujuanId");

                    b.HasIndex("GolonganId");

                    b.HasIndex("JenisPermintaanId");

                    b.HasIndex("LokasiId");

                    b.HasIndex("MppFormId");

                    b.HasIndex("PosisiId");

                    b.HasIndex("SumberPemenuhanId");

                    b.ToTable("MppChildForm");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.MppForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DivisiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsApprovalADH")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsApprovalBM")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsApprovalDirectorHC")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsApprovalDivHead")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsApprovalGMHC")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsApprovalHCBP")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsApprovalOPCC")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsApprovalPICA1B1")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDraft")
                        .HasColumnType("bit");

                    b.Property<Guid?>("JenisMppId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JenisPengajuan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("KategoriLokasiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaPemohon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoMpp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrpPemohon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TahunMpp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DivisiId");

                    b.HasIndex("JenisMppId");

                    b.HasIndex("KategoriLokasiId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("MppForm");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.Pendidikan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Pendidikan");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.Posisi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Posisi");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.SumberPemenuhan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SumberPemenuhan");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.User", b =>
                {
                    b.Property<string>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Division")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.MppChildForm", b =>
                {
                    b.HasOne("lunchBlazor.Shared.Models.Departemen", "Departemen")
                        .WithMany()
                        .HasForeignKey("DepartemenId");

                    b.HasOne("lunchBlazor.Shared.Models.Divisi", "DevisiTujuan")
                        .WithMany()
                        .HasForeignKey("DevisiTujuanId");

                    b.HasOne("lunchBlazor.Shared.Models.Golongan", "Golongan")
                        .WithMany()
                        .HasForeignKey("GolonganId");

                    b.HasOne("lunchBlazor.Shared.Models.JenisPermintaan", "JenisPermintaan")
                        .WithMany()
                        .HasForeignKey("JenisPermintaanId");

                    b.HasOne("lunchBlazor.Shared.Models.Lokasi", "Lokasi")
                        .WithMany()
                        .HasForeignKey("LokasiId");

                    b.HasOne("lunchBlazor.Shared.Models.MppForm", "MppForm")
                        .WithMany("MppChildForm")
                        .HasForeignKey("MppFormId");

                    b.HasOne("lunchBlazor.Shared.Models.Posisi", "Posisi")
                        .WithMany()
                        .HasForeignKey("PosisiId");

                    b.HasOne("lunchBlazor.Shared.Models.SumberPemenuhan", "SumberPemenuhan")
                        .WithMany()
                        .HasForeignKey("SumberPemenuhanId");

                    b.Navigation("Departemen");

                    b.Navigation("DevisiTujuan");

                    b.Navigation("Golongan");

                    b.Navigation("JenisPermintaan");

                    b.Navigation("Lokasi");

                    b.Navigation("MppForm");

                    b.Navigation("Posisi");

                    b.Navigation("SumberPemenuhan");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.MppForm", b =>
                {
                    b.HasOne("lunchBlazor.Shared.Models.Divisi", "Divisi")
                        .WithMany()
                        .HasForeignKey("DivisiId");

                    b.HasOne("lunchBlazor.Shared.Models.JenisMpp", "JenisMpp")
                        .WithMany()
                        .HasForeignKey("JenisMppId");

                    b.HasOne("lunchBlazor.Shared.Models.Lokasi", "KategoriLokasi")
                        .WithMany()
                        .HasForeignKey("KategoriLokasiId");

                    b.HasOne("lunchBlazor.Shared.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("lunchBlazor.Shared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Divisi");

                    b.Navigation("JenisMpp");

                    b.Navigation("KategoriLokasi");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("lunchBlazor.Shared.Models.MppForm", b =>
                {
                    b.Navigation("MppChildForm");
                });
#pragma warning restore 612, 618
        }
    }
}
