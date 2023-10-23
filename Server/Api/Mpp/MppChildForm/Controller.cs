using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MppChildFormController : ControllerBase
    {
        private readonly IMppChildFormService _IMppChildFormService;
        public MppChildFormController(IMppChildFormService service)
        {
            _IMppChildFormService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<MppChildForm>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IMppChildFormService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<MppChildForm>>> Post([FromBody] CreateMppChild items)
        {
            try
            {
                var dataList = await _IMppChildFormService.Post(items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMppChildForm([FromRoute] Guid id, [FromBody] CreateMppChild items)
        {
            try
            {
                var dataList = await _IMppChildFormService.Put(id, items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteMppChildForm([FromRoute] Guid id)
        {
            try
            {
                var dataList = await _IMppChildFormService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}