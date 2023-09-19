using Sieve.Attributes;

namespace lunchBlazor.Shared.Models
{
    public class BaseModel
    {
        [Sieve(CanFilter = true, CanSort = true, Name = "created")] public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? isDeleted { get; set; }
    }
}
