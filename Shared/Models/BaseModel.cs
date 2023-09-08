namespace lunchBlazor.Shared.Models
{
    public class BaseModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? isDeleted { get; set; }
    }
}
