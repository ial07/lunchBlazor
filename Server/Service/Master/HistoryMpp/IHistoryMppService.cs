using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IHistoryMppService
{
    Task<PageList<HistoryMpp>> Get(SieveModel model);
    Task<HistoryMpp> Post(CreateHistoryMpp model);
    Task<HistoryMpp> Put(Guid id, CreateHistoryMpp items);
    Task<HistoryMpp> Delete(Guid id);

}
