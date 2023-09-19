using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PendidikanController : ControllerBase
    {
        private readonly IPendidikanService _IPendidikanService;
        public PendidikanController(IPendidikanService PendidikanService)
        {
            _IPendidikanService = PendidikanService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pendidikan>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IPendidikanService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Pendidikan>>> Post([FromBody] CreateDevisiInput items)
        {
            try
            {
                var dataList = await _IPendidikanService.Post(items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevisi([FromRoute] Guid id, [FromBody] UpdateDevisiInput items)
        {
            try
            {
                var dataList = await _IPendidikanService.Put(id, items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteDevisi([FromRoute] Guid id)
        {
            try
            {
                var dataList = await _IPendidikanService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}