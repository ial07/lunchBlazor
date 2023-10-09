using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IUserService
{
    Task<PageList<Users>> Get(SieveModel model);
    Task<Users> Post(UserForm model);
    Task<Users> Put(Guid id, UserForm items);
    Task<Users> Delete(Guid id);

}
