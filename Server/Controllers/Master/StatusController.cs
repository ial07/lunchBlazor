using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _IStatusService;
        public StatusController(IStatusService service)
        {
            _IStatusService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Status>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IStatusService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Status>>> Post([FromBody] CreateDevisiInput items)
        {
            try
            {
                var dataList = await _IStatusService.Post(items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus([FromRoute] int id, [FromBody] UpdateDevisiInput items)
        {
            try
            {
                var dataList = await _IStatusService.Put(id, items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteStatus([FromRoute] int id)
        {
            try
            {
                var dataList = await _IStatusService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}