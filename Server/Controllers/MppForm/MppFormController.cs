using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MppFormController : ControllerBase
    {
        private readonly IMppFormService _IMppFormService;
        public MppFormController(IMppFormService service)
        {
            _IMppFormService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<MppForm>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IMppFormService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<MppForm>>> Post([FromBody] CreateMpp items)
        {
            try
            {
                var dataList = await _IMppFormService.Post(items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMppForm([FromRoute] Guid id, [FromBody] CreateMpp items)
        {
            try
            {
                var dataList = await _IMppFormService.Put(id, items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteMppForm([FromRoute] Guid id)
        {
            try
            {
                var dataList = await _IMppFormService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}