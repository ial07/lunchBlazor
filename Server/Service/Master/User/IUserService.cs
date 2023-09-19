using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IUserService
{
    Task<PageList<User>> Get(SieveModel model);
    Task<User> Post(UserForm model);
    Task<User> Put(Guid id, UserForm items);
    Task<User> Delete(Guid id);

}
