using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IPendidikanService
{
    Task<PageList<Pendidikan>> Get(SieveModel model);
    Task<Pendidikan> Post(CreateDevisiInput model);
    Task<Pendidikan> Put(Guid id, UpdateDevisiInput items);
    Task<Pendidikan> Delete(Guid id);

}
