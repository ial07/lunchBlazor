using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface ILokasiService
{
    Task<List<Lokasi>> Get(SieveModel model);
    Task<Lokasi> Post(CreateDevisiInput model);
    Task<Lokasi> Put(Guid id, UpdateDevisiInput items);
    Task<Lokasi> Delete(Guid id);

}
