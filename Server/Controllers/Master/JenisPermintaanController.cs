using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JenisPermintaanController : ControllerBase
    {
        private readonly IJenisPermintaanService _IJenisPermintaanService;
        public JenisPermintaanController(IJenisPermintaanService service)
        {
            _IJenisPermintaanService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<JenisPermintaan>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IJenisPermintaanService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<JenisPermintaan>>> Post([FromBody] CreateDevisiInput items)
        {
            try
            {
                var dataList = await _IJenisPermintaanService.Post(items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJenisPermintaan([FromRoute] Guid id, [FromBody] UpdateDevisiInput items)
        {
            try
            {
                var dataList = await _IJenisPermintaanService.Put(id, items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteJenisPermintaan([FromRoute] Guid id)
        {
            try
            {
                var dataList = await _IJenisPermintaanService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}