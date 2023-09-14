using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IMppChildFormService
{
    Task<PageList<MppChildForm>> Get(SieveModel model);
    Task<MppChildForm> Post(CreateMppChild model);
    Task<MppChildForm> Put(Guid id, CreateMppChild items);
    Task<MppChildForm> Delete(Guid id);

}
