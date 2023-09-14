using Sieve.Attributes;

namespace lunchBlazor.Shared.Models
{
    public class HistoryMpp : BaseModel
    {
        [Sieve(CanFilter = true, CanSort = true)] public Guid Id { get; set; }
        public string? Notes { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public Guid? UserId { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public Guid? MppId { get; set; }


        public bool? IsActive { get; set; }
    }
}
