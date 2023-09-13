using Sieve.Attributes;

namespace lunchBlazor.Shared.Models
{
    public class MppChildForm : BaseModel
    {
        public Guid Id { get; set; }
        public MppForm? MppForm { get; set; }
        public Guid? MppFormId { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? Name { get; set; }
        /// <Informasi MP Planning>
        public Posisi? Posisi { get; set; }
        public Departemen? Departemen { get; set; }
        public Golongan? Golongan { get; set; }
        public DateTime? TargetPemenuhan { get; set; }
        public Devisi? DevisiTujuan { get; set; }
        public Lokasi? Lokasi { get; set; }
        public Devisi? Devisi { get; set; }
        public int? JumlahMp { get; set; }
        public int? JumlahPermintaan { get; set; }
        public string? AlasanPengajuan { get; set; }
        /// <Status Pemenuhan>
        public JenisPermintaan? JenisPermintaan { get; set; }
        public SumberPemenuhan? SumberPemenuhan { get; set; }
        public string? DetailSumberPemenuhan { get; set; }
        /// <Informasi Detail Pekerjaan>
        public string? PosisiManPower { get; set; }
        public string? DetailPekerjaan { get; set; }
        public string? Lulusan { get; set; }
        public string? NamaLulusan { get; set; }
        public string? JenisKelamin { get; set; }
        public int? Usia { get; set; }
        public bool? StatusPernikahan { get; set; }
        public bool? StatusPegawai { get; set; }
        public string? PengalamanKerja { get; set; }
        public string? KeahlianKhusus { get; set; }
        public string? PersyaratanFisik { get; set; }
        public string? CatatanTambahan { get; set; }
        public string? Keterangan { get; set; }
        public bool? IsActive { get; set; }

    }
}
