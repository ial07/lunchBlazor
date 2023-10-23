using man_power_planning.Shared.Helper;
using man_power_planning.Shared.Models;
using Sieve.Models;

public interface IHistoryMppService
{
    Task<PageList<HistoryMpp>> Get(SieveModel model);
    Task<Object> Post(CreateHistoryMpp model);
    Task<Object> Put(Guid id, CreateHistoryMpp items);
    Task<Object> GetId(Guid id);
    Task<Object> Delete(Guid id);

}
