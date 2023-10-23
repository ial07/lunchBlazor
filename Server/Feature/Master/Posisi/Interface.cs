using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IPosisiService
{
    Task<PageList<Posisi>> Get(SieveModel model);
    Task<Object> Post(CreateDto model);
    Task<Object> Put(Guid id, UpdateDto items);
    Task<Object> GetId(Guid id);
    Task<Object> Delete(Guid id);

}
