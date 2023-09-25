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
        public MppFormController(IMppFormService service)
        {
            _IMppFormService = service;
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
                // Access the Bearer token from the request headers
                string accessToken = HttpContext.Request.Headers["Authorization"];
                // Check if the Authorization header is present and starts with "Bearer "
                if (!string.IsNullOrWhiteSpace(accessToken) && accessToken.StartsWith("Bearer "))
                {
                    // Remove "Bearer " prefix to get just the token
                    accessToken = accessToken.Substring("Bearer ".Length);
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.ReadJwtToken(accessToken);
                    string idUser = token.Subject;
                    var dataList = await _IMppFormService.Post(idUser);
                    return Ok(dataList);
                }
                else
                {
                    return Unauthorized(); // Return a 401 Unauthorized response if the token is missing or not in the correct format
                }
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