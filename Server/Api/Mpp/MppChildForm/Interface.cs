using man_power_planning.Shared.Helper;
using man_power_planning.Shared.Models;
using Sieve.Models;

public interface IMppChildFormService
{
    Task<PageList<MppChildForm>> Get(SieveModel model);
    Task<MppChildForm> Post(CreateMppChild model);
    Task<MppChildForm> Put(Guid id, CreateMppChild items);
    Task<MppChildForm> Delete(Guid id);

}
