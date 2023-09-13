using System.ComponentModel.DataAnnotations;

public class CreateMpp
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string NrpPemohon { get; set; }
    [Required]
    public string NamaPemohon { get; set; }
    [Required]
    public Guid KategoriLokasiId { get; set; }
    [Required]
    public Guid DevisiId { get; set; }
    [Required]
    public Guid JenisMppId { get; set; }
    [Required]
    public DateTime TahunMpp { get; set; }
    [Required]
    public bool IsApprovalADH { get; set; }
    [Required]
    public bool IsApprovalBM { get; set; }
    [Required]
    public bool IsApprovalHCBP { get; set; }
    [Required]
    public bool IsApprovalDivHead { get; set; }
    [Required]
    public bool IsApprovalPICA1B1 { get; set; }
    [Required]
    public bool IsApprovalOPCC { get; set; }
    [Required]
    public bool IsApprovalGMHC { get; set; }
    [Required]
    public bool IsApprovalDirectorHC { get; set; }
    [Required]
    public bool IsDraft { get; set; }
    [Required]
    public bool IsActive { get; set; }
}