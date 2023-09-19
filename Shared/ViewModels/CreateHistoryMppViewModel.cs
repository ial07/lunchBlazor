using System.ComponentModel.DataAnnotations;

public class CreateHistoryMpp
{
    public string? Notes { get; set; }

    public Guid? UserId { get; set; }
    public Guid? MppId { get; set; }

    public bool IsActive { get; set; }
}