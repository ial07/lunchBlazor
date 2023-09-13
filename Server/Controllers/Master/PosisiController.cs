using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PosisiController : ControllerBase
    {
        private readonly IPosisiService _IPosisiService;
        public PosisiController(IPosisiService service)
        {
            _IPosisiService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Posisi>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IPosisiService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Posisi>>> Post([FromBody] CreateDevisiInput items)
        {
            try
            {
                var dataList = await _IPosisiService.Post(items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePosisi([FromRoute] Guid id, [FromBody] UpdateDevisiInput items)
        {
            try
            {
                var dataList = await _IPosisiService.Put(id, items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeletePosisi([FromRoute] Guid id)
        {
            try
            {
                var dataList = await _IPosisiService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}