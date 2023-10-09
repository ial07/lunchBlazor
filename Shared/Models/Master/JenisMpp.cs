using Sieve.Attributes;

namespace lunchBlazor.Shared.Models
{
    public class JenisMpp : BaseModel
    {
        [Sieve(CanFilter = true, CanSort = true)] public Guid Id { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? Name { get; set; }
    }
}
