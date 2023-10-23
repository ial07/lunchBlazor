using Microsoft.AspNetCore.Mvc;

namespace blazor.Server.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _IAuthService;
        private readonly ErrorHandlingUtility _errorUtility;
        private readonly ValidationAuthDto _masterValidationService;
        public AuthController(IAuthService authService, ValidationAuthDto MasterValidationService)
        {
            _IAuthService = authService;
            _errorUtility = new ErrorHandlingUtility();
            _masterValidationService = MasterValidationService;
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto login)
        {
            var validationErrors = _masterValidationService.ValidateCreateInput(login);
            if (validationErrors.Count > 0)
            {
                var errorResponse = new { code = 400, errorMessage = validationErrors };
                return BadRequest(errorResponse);
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