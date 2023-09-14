using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface ILokasiService
{
    Task<PageList<Lokasi>> Get(SieveModel model);
    Task<Lokasi> Post(CreateDevisiInput model);
    Task<Lokasi> Put(Guid id, UpdateDevisiInput items);
    Task<Lokasi> Delete(Guid id);

}
