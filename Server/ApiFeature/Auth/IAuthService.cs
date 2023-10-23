using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Sieve.Models;

public interface IAuthService
{
    Task<PageList<Users>> Get(SieveModel model);
    Task<Users> Post(LoginDto model);
    Task<Object> LoginAsync(LoginDto model);
    Task<Users> Put(Guid id, LoginDto items);
    Task<Users> Delete(Guid id);

}
