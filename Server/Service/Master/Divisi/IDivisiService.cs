using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IDivisiService
{
    Task<PageList<Divisi>> Get(SieveModel model);
    Task<Divisi> Post(CreateDevisiInput model);
    Task<Divisi> Put(Guid id, UpdateDevisiInput items);
    Task<Divisi> Delete(Guid id);

}
