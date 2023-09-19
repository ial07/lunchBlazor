using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DepartemenController : ControllerBase
    {
        private readonly IDepartemenService _IDepartemenService;
        public DepartemenController(IDepartemenService departemenService)
        {
            _IDepartemenService = departemenService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Departemen>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IDepartemenService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Departemen>>> Post([FromBody] CreateDevisiInput items)
        {
            try
            {
                var dataList = await _IDepartemenService.Post(items);
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
                var dataList = await _IDepartemenService.Put(id, items);
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
                var dataList = await _IDepartemenService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}