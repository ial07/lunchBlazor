using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LokasiController : ControllerBase
    {
        private readonly ILokasiService _ILokasiService;
        public LokasiController(ILokasiService service)
        {
            _ILokasiService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lokasi>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _ILokasiService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Lokasi>>> Post([FromBody] CreateDevisiInput items)
        {
            try
            {
                var dataList = await _ILokasiService.Post(items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLokasi([FromRoute] Guid id, [FromBody] UpdateDevisiInput items)
        {
            try
            {
                var dataList = await _ILokasiService.Put(id, items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteLokasi([FromRoute] Guid id)
        {
            try
            {
                var dataList = await _ILokasiService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}