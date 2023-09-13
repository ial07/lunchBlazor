using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IMppChildFormService
{
    Task<List<MppChildForm>> Get(SieveModel model);
    Task<MppChildForm> Post(CreateMpp model);
    Task<MppChildForm> Put(Guid id, CreateMpp items);
    Task<MppChildForm> Delete(Guid id);

}
