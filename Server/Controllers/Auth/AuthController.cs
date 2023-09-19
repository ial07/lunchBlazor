using lunchBlazor.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json;
using lunchBlazor.Shared.Models;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _IAuthService;
        public AuthController(IAuthService authService)
        {
            _IAuthService = authService;
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserForm login)
        {
            try
            {
                var dataList = await _IAuthService.LoginAsync(login);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

}