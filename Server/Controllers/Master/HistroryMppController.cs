using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryMppController : ControllerBase
    {
        private readonly IHistoryMppService _IHistoryMppService;
        public HistoryMppController(IHistoryMppService service)
        {
            _IHistoryMppService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<HistoryMpp>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IHistoryMppService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<HistoryMpp>>> Post([FromBody] CreateHistoryMpp items)
        {
            try
            {
                var dataList = await _IHistoryMppService.Post(items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHistoryMpp([FromRoute] Guid id, [FromBody] CreateHistoryMpp items)
        {
            try
            {
                var dataList = await _IHistoryMppService.Put(id, items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteHistoryMpp([FromRoute] Guid id)
        {
            try
            {
                var dataList = await _IHistoryMppService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}