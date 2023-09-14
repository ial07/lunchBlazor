using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IMppFormService
{
    Task<List<MppForm>> Get(SieveModel model);
    Task<MppForm> Post(CreateMpp model);
    Task<MppForm> Put(Guid id, UpdateMpp items);
    Task<MppForm> Delete(Guid id);

}
