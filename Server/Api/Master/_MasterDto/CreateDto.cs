public class CreateDto
{
    public string? Name { get; set; }
    public string? Image { get; set; }
}

public class CreateHistoryMpp
{
    public string? Notes { get; set; }
    public Guid? UserId { get; set; }
    public Guid? MppId { get; set; }
}