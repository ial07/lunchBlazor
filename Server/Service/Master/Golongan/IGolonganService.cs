using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IGolonganService
{
    Task<List<Golongan>> Get(SieveModel model);
    Task<Golongan> Post(CreateDevisiInput model);
    Task<Golongan> Put(Guid id, UpdateDevisiInput items);
    Task<Golongan> Delete(Guid id);

}
