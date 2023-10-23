using man_power_planning.Shared.Helper;
using man_power_planning.Shared.Models;
using Sieve.Models;

public interface IStatusService
{
    Task<PageList<Status>> Get(SieveModel model);
    Task<Object> Post(CreateDto model);
    Task<Object> Put(int id, UpdateDto items);
    Task<Object> GetId(int id);
    Task<Object> Delete(int id);

}
