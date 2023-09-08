namespace lunchBlazor.Shared.Models
{
    public class Banner : BaseModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public bool? IsActive { get; set; }
    }
}
