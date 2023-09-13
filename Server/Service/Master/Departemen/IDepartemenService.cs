using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IDepartemenService
{
    Task<List<Departemen>> Get(SieveModel model);
    Task<Departemen> Post(CreateDevisiInput model);
    Task<Departemen> Put(Guid id, UpdateDevisiInput items);
    Task<Departemen> Delete(Guid id);

}
