using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JenisMppController : ControllerBase
    {
        private readonly IJenisMppService _IJenisMppService;
        public JenisMppController(IJenisMppService service)
        {
            _IJenisMppService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<JenisMpp>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IJenisMppService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<JenisMpp>>> Post([FromBody] CreateDevisiInput items)
        {
            try
            {
                var dataList = await _IJenisMppService.Post(items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJenisMpp([FromRoute] Guid id, [FromBody] UpdateDevisiInput items)
        {
            try
            {
                var dataList = await _IJenisMppService.Put(id, items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteJenisMpp([FromRoute] Guid id)
        {
            try
            {
                var dataList = await _IJenisMppService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}