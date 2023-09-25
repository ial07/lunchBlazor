using System.IdentityModel.Tokens.Jwt;
using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MppFormController : ControllerBase
    {
        private readonly IMppFormService _IMppFormService;
        private readonly ConvertJWT _ConvertJwt;
        public MppFormController(IMppFormService service, ConvertJWT convert)
        {
            _IMppFormService = service;
            _ConvertJwt = convert;
        }

        [HttpGet]
        public async Task<ActionResult<List<MppForm>>> Get([FromQuery] SieveModel model)
        {
            try
            {
                var dataList = await _IMppFormService.Get(model);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<List<MppForm>>> Post()
        {
            try
            {
                string accessToken = HttpContext.Request.Headers["Authorization"];
                User checktoken = await _ConvertJwt.ConvertString(accessToken);
                var dataList = await _IMppFormService.Post(checktoken);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMppForm([FromRoute] Guid id, [FromBody] UpdateMpp items)
        {
            try
            {
                var dataList = await _IMppFormService.Put(id, items);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpPut("Approval/{id}")]
        public async Task<IActionResult> Approval([FromRoute] Guid id)
        {
            try
            {
                string accessToken = HttpContext.Request.Headers["Authorization"];
                User checktoken = await _ConvertJwt.ConvertString(accessToken);
                var dataList = await _IMppFormService.PutApproval(id, checktoken);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteMppForm([FromRoute] Guid id)
        {
            try
            {
                var dataList = await _IMppFormService.Delete(id);
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}