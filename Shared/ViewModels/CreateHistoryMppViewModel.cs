using System.ComponentModel.DataAnnotations;

public class CreateHistoryMpp
{
    [Required]
    public string? Notes { get; set; }

    [Required]
    public Guid? UserId { get; set; }
    [Required]
    public Guid? MppId { get; set; }

    [Required]
    public bool IsActive { get; set; }
}