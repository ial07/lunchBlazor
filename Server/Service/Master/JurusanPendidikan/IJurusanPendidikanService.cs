using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IJurusanPendidikanService
{
    Task<PageList<JurusanPendidikan>> Get(SieveModel model);
    Task<JurusanPendidikan> Post(CreateDevisiInput model);
    Task<JurusanPendidikan> Put(Guid id, UpdateDevisiInput items);
    Task<JurusanPendidikan> Delete(Guid id);

}
