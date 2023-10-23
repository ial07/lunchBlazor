

using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace blazor.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class JenisMppController : ControllerBase
    {
        private readonly IJenisMppService _IJenisMppService;
        private readonly ErrorHandlingUtility _errorUtility;
        private readonly ValidationDto _masterValidationService;
        public JenisMppController(IJenisMppService JenisMppService, ValidationDto MasterValidationService)
        {
            _IJenisMppService = JenisMppService;
            _errorUtility = new ErrorHandlingUtility();
            _masterValidationService = MasterValidationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IJenisMppService.Get(model);
                return Ok(dataList);
            }
            catch (CustomException ex)
            {
                int errorCode = ex.ErrorCode;
                var errorResponse = new ErrorResponse(errorCode, ex.Message);
                return _errorUtility.HandleError(errorCode, errorResponse);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId([FromRoute] Guid id)
        {
            try
            {
                var dataList = await _IJenisMppService.GetId(id);
                return Ok(dataList);
            }
            catch (CustomException ex)
            {
                int errorCode = ex.ErrorCode;
                var errorResponse = new ErrorResponse(errorCode, ex.Message);
                return _errorUtility.HandleError(errorCode, errorResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDto items)
        {


            try
            {
                var validationErrors = _masterValidationService.ValidateCreateInput(items);
                if (validationErrors.Count > 0)
                {
                    var errorResponse = new { code = 400, errorMessage = validationErrors };
                    return BadRequest(errorResponse);
                }
                var dataList = await _IJenisMppService.Post(items);
                return Ok(dataList);
            }
            catch (CustomException ex)
            {
                int errorCode = ex.ErrorCode;
                var errorResponse = new ErrorResponse(errorCode, ex.Message);
                return _errorUtility.HandleError(errorCode, errorResponse);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevisi([FromRoute] Guid id, [FromBody] UpdateDto items)
        {
            try
            {
                var validationErrors = _masterValidationService.ValidateUpdateInput(items);
                if (validationErrors.Count > 0)
                {
                    var errorResponse = new { code = 400, errorMessage = validationErrors };
                    return BadRequest(errorResponse);
                }
                var dataList = await _IJenisMppService.Put(id, items);
                return Created("", dataList);
            }
            catch (CustomException ex)
            {
                int errorCode = ex.ErrorCode;
                var errorResponse = new ErrorResponse(errorCode, ex.Message);
                return _errorUtility.HandleError(errorCode, errorResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteDevisi([FromRoute] Guid id)
        {
            try
            {
                var dataList = await _IJenisMppService.Delete(id);
                return Created("", dataList);
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