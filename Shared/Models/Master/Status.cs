using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sieve.Attributes;

namespace lunchBlazor.Shared.Models
{
    public class Status : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Sieve(CanFilter = true, CanSort = true)] public int Id { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? Name { get; set; }
        [Sieve(CanFilter = true, CanSort = true)] public string? Image { get; set; }
    }
}
