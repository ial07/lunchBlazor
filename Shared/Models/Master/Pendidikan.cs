using Sieve.Attributes;

namespace lunchBlazor.Shared.Models
{
    public class Pendidikan : BaseModel
    {
        [Sieve(CanFilter = true, CanSort = true)] public Guid Id { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
