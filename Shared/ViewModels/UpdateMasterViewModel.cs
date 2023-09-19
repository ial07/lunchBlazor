using System.ComponentModel.DataAnnotations;

public class UpdateDevisiInput
{
    public string? Name { get; set; }
    public string? Image { get; set; }
    public bool IsActive { get; set; }
}