using Microsoft.AspNetCore.Mvc;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _IAuthService;
        private readonly ErrorHandlingUtility _errorUtility;
        public AuthController(IAuthService authService)
        {
            _IAuthService = authService;
            _errorUtility = new ErrorHandlingUtility();
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserForm login)
        {
            if (login.UserID == null || login.Password == null)
            {
                throw new CustomException(400, "UserId atau Password Wajib diisi");
            }
            try
            {
                var dataList = await _IAuthService.LoginAsync(login);
                return Ok(dataList);
            }
            catch (CustomException ex)
            {
                int errorCode = ex.ErrorCode;
                var errorResponse = new ErrorResponse(errorCode, ex.Message);
                return _errorUtility.HandleError(errorCode, errorResponse);
            }
        }
    }

}