

using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace blazor.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _IStatusService;
        private readonly ErrorHandlingUtility _errorUtility;
        private readonly ValidationDto _masterValidationService;
        public StatusController(IStatusService StatusService, ValidationDto MasterValidationService)
        {
            _IStatusService = StatusService;
            _errorUtility = new ErrorHandlingUtility();
            _masterValidationService = MasterValidationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IStatusService.Get(model);
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
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            try
            {
                var dataList = await _IStatusService.GetId(id);
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
                var dataList = await _IStatusService.Post(items);
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
        public async Task<IActionResult> UpdateDevisi([FromRoute] int id, [FromBody] UpdateDto items)
        {
            try
            {
                var validationErrors = _masterValidationService.ValidateUpdateInput(items);
                if (validationErrors.Count > 0)
                {
                    var errorResponse = new { code = 400, errorMessage = validationErrors };
                    return BadRequest(errorResponse);
                }
                var dataList = await _IStatusService.Put(id, items);
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
        public async Task<IActionResult> SoftDeleteDevisi([FromRoute] int id)
        {
            try
            {
                var dataList = await _IStatusService.Delete(id);
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