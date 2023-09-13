using Sieve.Attributes;

namespace lunchBlazor.Shared.Models
{
    public class Status : BaseModel
    {
        [Sieve(CanFilter = true, CanSort = true)] public Guid Id { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? Name { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? Image { get; set; }
        public bool? IsActive { get; set; }
    }
}
