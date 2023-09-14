using Sieve.Attributes;

namespace lunchBlazor.Shared.Models
{
    public class MppForm : BaseModel
    {
        [Sieve(CanFilter = true, CanSort = true)] public Guid Id { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? NoMpp { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? Name { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? NrpPemohon { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? NamaPemohon { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public Guid? KategoriLokasiId { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public Guid? DevisiId { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public Guid? JenisMppId { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public Guid? StatusId { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public DateTime? TahunMpp { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalADH { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalBM { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalHCBP { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalDivHead { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalPICA1B1 { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalOPCC { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalGMHC { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalDirectorHC { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsActive { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsDraft { get; set; }
        public string? Keterangan { get; set; }
        public List<MppChildForm>? MppChildForm { get; set; }
        public Lokasi? KategoriLokasi { get; set; }
        public Devisi? Devisi { get; set; }
        public Status? Status { get; set; }
        public JenisMpp? JenisMpp { get; set; }

    }
}
