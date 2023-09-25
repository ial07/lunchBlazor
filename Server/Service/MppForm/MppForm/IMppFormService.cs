using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IMppFormService
{
    Task<PageList<MppForm>> Get(SieveModel model);
    Task<Guid> Post(User idUser);
    Task<MppForm> Put(Guid id, UpdateMpp items);
    Task<MppForm> PutApproval(Guid id, User items);
    Task<MppForm> Delete(Guid id);
}
