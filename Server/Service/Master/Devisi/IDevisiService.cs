using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IDevisiService
{
    Task<List<Devisi>> Get(SieveModel model);
    Task<Devisi> Post(CreateDevisiInput model);
    Task<Devisi> Put(Guid id, UpdateDevisiInput items);
    Task<Devisi> Delete(Guid id);

}
