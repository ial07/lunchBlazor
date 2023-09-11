using System.ComponentModel.DataAnnotations;

public class CreateMpp
{
    [Required]
    public string Name { get; set; }

    [Required]
    public bool IsActive { get; set; }
}