using Sieve.Attributes;

namespace lunchBlazor.Shared.Models
{
    public class MppChildForm : BaseModel
    {
        public Guid Id { get; set; }
        public MppForm? MppForm { get; set; }
        public Guid? MppFormId { get; set; }
        /// <Informasi MP Planning>
        [Sieve(CanFilter = true, CanSort = true)] public string? Name { get; set; }

        public Posisi? Posisi { get; set; }
        public Guid? PosisiId { get; set; }

        public Golongan? Golongan { get; set; }
        public Guid? GolonganId { get; set; }

        public DateTime? TargetPemenuhan { get; set; }

        public Divisi? DevisiTujuan { get; set; }
        public Guid? DevisiTujuanId { get; set; }

        public Departemen? Departemen { get; set; }
        public Guid? DepartemenId { get; set; }

        public Lokasi? Lokasi { get; set; }
        public Guid? LokasiId { get; set; }
        public string? NamaLokasi { get; set; }

        public int? JumlahMp { get; set; }
        public int? JumlahPermintaan { get; set; }
        public string? AlasanPengajuan { get; set; }
        /// <Status Pemenuhan>
        public JenisPermintaan? JenisPermintaan { get; set; }
        public Guid? JenisPermintaanId { get; set; }

        public SumberPemenuhan? SumberPemenuhan { get; set; }
        public Guid? SumberPemenuhanId { get; set; }

        public string? DetailSumberPemenuhan { get; set; }
        /// <Informasi Detail Pekerjaan>
        public string? PosisiManPower { get; set; }
        public string? DetailPekerjaan { get; set; }
        public Pendidikan? Pendidikan { get; set; }
        public JurusanPendidikan? JurusanPendidikan { get; set; }
        public string? Gender { get; set; }
        public int? Usia { get; set; }
        public bool? StatusPernikahan { get; set; }
        public string? StatusPegawai { get; set; }
        public string? PengalamanKerja { get; set; }
        public string? KeahlianKhusus { get; set; }
        public string? PersyaratanFisik { get; set; }
        public string? CatatanTambahan { get; set; }
        public string? Keterangan { get; set; }
        public bool? IsActive { get; set; }

    }
}
