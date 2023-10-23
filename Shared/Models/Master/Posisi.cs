using Sieve.Attributes;

namespace man_power_planning.Shared.Models
{
    public class Posisi : BaseModel
    {
        [Sieve(CanFilter = true, CanSort = true)] public Guid Id { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? Name { get; set; }
    }
}
