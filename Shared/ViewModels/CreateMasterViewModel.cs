using System.ComponentModel.DataAnnotations;

public class CreateDevisiInput
{
    [Required]
    public string Name { get; set; }

    [Required]
    public bool IsActive { get; set; }
}