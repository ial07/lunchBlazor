using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IJenisMppService
{
    Task<List<JenisMpp>> Get(SieveModel model);
    Task<JenisMpp> Post(CreateDevisiInput model);
    Task<JenisMpp> Put(Guid id, UpdateDevisiInput items);
    Task<JenisMpp> Delete(Guid id);

}
