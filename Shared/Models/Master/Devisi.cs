using Sieve.Attributes;

namespace lunchBlazor.Shared.Models
{
    public class Devisi : BaseModel
    {
        public Guid Id { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }
}