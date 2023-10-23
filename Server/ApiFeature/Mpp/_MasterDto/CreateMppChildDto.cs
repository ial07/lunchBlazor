using System.ComponentModel.DataAnnotations;

public class CreateMppChild
{
    public Guid? MppFormId { get; set; }
    /// <Informasi MP Planning>
    public string? Name { get; set; }

    public Guid? PosisiId { get; set; }

    public Guid? GolonganId { get; set; }

    public DateTime? TargetPemenuhan { get; set; }

    public Guid? DevisiTujuanId { get; set; }

    public Guid? DepartemenId { get; set; }

    public Guid? LokasiId { get; set; }
    public string? NamaLokasi { get; set; }

    public int? JumlahMp { get; set; }
    public int? JumlahPermintaan { get; set; }
    public string? AlasanPengajuan { get; set; }
    /// <Status Pemenuhan>
    public Guid? JenisPermintaanId { get; set; }

    public Guid? SumberPemenuhanId { get; set; }

    public string? DetailSumberPemenuhan { get; set; }
    /// <Informasi Detail Pekerjaan>
    public string? PosisiManPower { get; set; }
    public string? DetailPekerjaan { get; set; }
    public string? Lulusan { get; set; }
    public string? Jurusan { get; set; }
    public string? Gender { get; set; }
    public string? Usia { get; set; }
    public string? StatusPernikahan { get; set; }
    public string? StatusPegawai { get; set; }
    public string? PengalamanKerja { get; set; }
    public string? KeahlianKhusus { get; set; }
    public string? PersyaratanFisik { get; set; }
    public string? CatatanTambahan { get; set; }
    public string? Keterangan { get; set; }
    public string? Pengajuan { get; set; }
    public bool? IsActive { get; set; }
}