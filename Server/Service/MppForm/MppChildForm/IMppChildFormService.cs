using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IMppChildFormService
{
    Task<List<MppChildForm>> Get(SieveModel model);
    Task<MppChildForm> Post(CreateMppChild model);
    Task<MppChildForm> Put(Guid id, CreateMppChild items);
    Task<MppChildForm> Delete(Guid id);

}
