using Sieve.Attributes;

namespace lunchBlazor.Shared.Models
{
    public class Golongan : BaseModel
    {
        public Guid Id { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? Name { get; set; }
        public string? Image { get; set; }
        public bool? IsActive { get; set; }
    }
}