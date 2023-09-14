using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IJenisPermintaanService
{
    Task<PageList<JenisPermintaan>> Get(SieveModel model);
    Task<JenisPermintaan> Post(CreateDevisiInput model);
    Task<JenisPermintaan> Put(Guid id, UpdateDevisiInput items);
    Task<JenisPermintaan> Delete(Guid id);

}
