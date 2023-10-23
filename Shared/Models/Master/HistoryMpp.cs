using Sieve.Attributes;

namespace man_power_planning.Shared.Models
{
    public class HistoryMpp : BaseModel
    {
        [Sieve(CanFilter = true, CanSort = true)] public Guid Id { get; set; }
        public string? Notes { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public Guid? UserId { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public Guid? MppId { get; set; }
    }
}
