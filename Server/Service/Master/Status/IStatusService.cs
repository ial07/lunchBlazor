using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IStatusService
{
    Task<PageList<Status>> Get(SieveModel model);
    Task<Status> Post(CreateDevisiInput model);
    Task<Status> Put(Guid id, UpdateDevisiInput items);
    Task<Status> Delete(Guid id);

}
