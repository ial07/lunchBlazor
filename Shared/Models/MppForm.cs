using Sieve.Attributes;

namespace lunchBlazor.Shared.Models
{
    public class MppForm : BaseModel
    {
        public Guid Id { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? Name { get; set; }
        public string? NrpPemohon { get; set; }
        public string? NamaPemohon { get; set; }
        public Lokasi? KategoriLokasi { get; set; }
        public Guid? KategoriLokasiId { get; set; }
        public Devisi? Devisi { get; set; }
        public Guid? DevisiId { get; set; }
        public JenisMpp? JenisMpp { get; set; }
        public Guid? JenisMppId { get; set; }
        public DateTime? TahunMpp { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalADH { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalBM { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalHCBP { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalDivHead { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalPICA1B1 { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalOPCC { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalGMHC { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public bool? IsApprovalDirectorHC { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDraft { get; set; }
        public List<MppChildForm>? MppChildForm { get; set; }

    }
}
