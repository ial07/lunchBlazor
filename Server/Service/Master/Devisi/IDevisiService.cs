using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IDevisiService
{
    Task<PageList<Devisi>> Get(SieveModel model);
    Task<Devisi> Post(CreateDevisiInput model);
    Task<Devisi> Put(Guid id, UpdateDevisiInput items);
    Task<Devisi> Delete(Guid id);

}
