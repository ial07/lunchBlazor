using Sieve.Attributes;

namespace man_power_planning.Shared.Models
{
    public class BaseModel
    {
        [Sieve(CanFilter = true, CanSort = true, Name = "created")] public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsActive { get; set; }
    }
}
