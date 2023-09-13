using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface ISumberPemenuhanService
{
    Task<List<SumberPemenuhan>> Get(SieveModel model);
    Task<SumberPemenuhan> Post(CreateDevisiInput model);
    Task<SumberPemenuhan> Put(Guid id, UpdateDevisiInput items);
    Task<SumberPemenuhan> Delete(Guid id);

}
