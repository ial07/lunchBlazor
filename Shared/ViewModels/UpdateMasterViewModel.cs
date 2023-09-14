using System.ComponentModel.DataAnnotations;

public class UpdateDevisiInput
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Image { get; set; }
    [Required]
    public bool IsActive { get; set; }
}