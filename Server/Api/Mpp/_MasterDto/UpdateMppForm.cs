using System.ComponentModel.DataAnnotations;

public class UpdateMpp
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? NrpPemohon { get; set; }
    [Required]
    public string? NoMpp { get; set; }
    [Required]
    public string? NamaPemohon { get; set; }
    [Required]
    public string? UserId { get; set; }
    [Required]
    public int StatusId { get; set; }
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
    public bool IsApprovalHCBP { get; set; }
    [Required]
    public bool IsApprovalBM { get; set; }
    public bool IsApprovalDivHead { get; set; }
    public bool IsApprovalPICA1B1 { get; set; }
    public bool IsApprovalOPCC { get; set; }
    public bool IsApprovalGMHC { get; set; }
    public bool IsApprovalDirectorHC { get; set; }
    [Required]
    public bool IsDraft { get; set; }
    [Required]
    public bool IsActive { get; set; }
}