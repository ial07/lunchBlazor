using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IPosisiService
{
    Task<PageList<Posisi>> Get(SieveModel model);
    Task<Posisi> Post(CreateDevisiInput model);
    Task<Posisi> Put(Guid id, UpdateDevisiInput items);
    Task<Posisi> Delete(Guid id);

}