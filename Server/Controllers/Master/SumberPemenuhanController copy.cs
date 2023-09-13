using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SumberPemenuhanController : ControllerBase
    {
        private readonly ISumberPemenuhanService _ISumberPemenuhanService;
        public SumberPemenuhanController(ISumberPemenuhanService service)
        {
            _ISumberPemenuhanService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SumberPemenuhan>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _ISumberPemenuhanService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<SumberPemenuhan>>> Post([FromBody] CreateDevisiInput items)
        {
            try
            {
                var dataList = await _ISumberPemenuhanService.Post(items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSumberPemenuhan([FromRoute] Guid id, [FromBody] UpdateDevisiInput items)
        {
            try
            {
                var dataList = await _ISumberPemenuhanService.Put(id, items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteSumberPemenuhan([FromRoute] Guid id)
        {
            try
            {
                var dataList = await _ISumberPemenuhanService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}