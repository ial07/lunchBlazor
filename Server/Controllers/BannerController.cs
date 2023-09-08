using lunchBlazor.Server.Services.BannerService;
using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _BannerService;
        public BannerController(IBannerService BannerService)
        {
            _BannerService = BannerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Banner>>> GetBanners()
        {
            return Ok(await _BannerService.GetBanners());
        }


    }
}