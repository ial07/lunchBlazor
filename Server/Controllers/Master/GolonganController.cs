using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GolonganController : ControllerBase
    {
        private readonly IGolonganService _IGolonganService;
        public GolonganController(IGolonganService service)
        {
            _IGolonganService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Golongan>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IGolonganService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Golongan>>> Post([FromBody] CreateDevisiInput items)
        {
            try
            {
                var dataList = await _IGolonganService.Post(items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGolongan([FromRoute] Guid id, [FromBody] UpdateDevisiInput items)
        {
            try
            {
                var dataList = await _IGolonganService.Put(id, items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteGolongan([FromRoute] Guid id)
        {
            try
            {
                var dataList = await _IGolonganService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}