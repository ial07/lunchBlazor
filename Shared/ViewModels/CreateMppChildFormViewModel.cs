using System.ComponentModel.DataAnnotations;

public class CreateMppChild
{
    [Required]
    public string Name { get; set; }

    [Required]
    public bool IsActive { get; set; }
}