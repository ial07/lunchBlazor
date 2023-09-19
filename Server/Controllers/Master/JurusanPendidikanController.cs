using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JurusanPendidikanController : ControllerBase
    {
        private readonly IJurusanPendidikanService _IJurusanPendidikanService;
        public JurusanPendidikanController(IJurusanPendidikanService JurusanPendidikanService)
        {
            _IJurusanPendidikanService = JurusanPendidikanService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JurusanPendidikan>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IJurusanPendidikanService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<JurusanPendidikan>>> Post([FromBody] CreateDevisiInput items)
        {
            try
            {
                var dataList = await _IJurusanPendidikanService.Post(items);
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
                var dataList = await _IJurusanPendidikanService.Put(id, items);
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
                var dataList = await _IJurusanPendidikanService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}