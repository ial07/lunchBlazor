using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IJenisMppService
{
    Task<PageList<JenisMpp>> Get(SieveModel model);
    Task<JenisMpp> Post(CreateDevisiInput model);
    Task<JenisMpp> Put(Guid id, UpdateDevisiInput items);
    Task<JenisMpp> Delete(Guid id);

}
