using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BannerController : ControllerBase
    {
        private readonly SieveProcessor _SieveProcessor;
        private readonly AppDbContext _AppDbContext;
        public BannerController(SieveProcessor sieveProcessor, AppDbContext AppDbContext)
        {
            _SieveProcessor = sieveProcessor;
            _AppDbContext = AppDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Banner>>> GetBanners([FromQuery] SieveModel model)
        {
            var banners = _AppDbContext.Banner.AsQueryable();
            var result = _SieveProcessor.Apply(model, banners);
            var Banners = await PageList<Banner>.CreateAsync(
                banners,
                result,
                model.Page,
                model.PageSize
            );
            return Ok(Banners);
        }

        // public async Task<PageList<Banner>> GetBanners(PageFilters filter)
        // {
        //     IQueryable<Banner> BannerQuery = _AppDbContext.Banner;
        //     if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
        //     {
        //         BannerQuery = BannerQuery.Where(b =>
        //         b.Name.Contains(filter.SearchTerm)
        //         );
        //     }

        //     var BannersResponseQuery = await BannerQuery
        //     .Select(b => new Banner
        //     {
        //         Id = b.Id,
        //         Name = b.Name,
        //         IsActive = b.IsActive,
        //         Image = b.Image,
        //         isDeleted = b.isDeleted,
        //         CreatedAt = b.CreatedAt,
        //         UpdatedAt = b.UpdatedAt,
        //     }).ToListAsync();

        //     var Banners = await PageList<Banner>.CreateAsync(
        //         BannersResponseQuery,
        //         filter.Page,
        //         filter.PageSize
        //     );
        //     return Banners;
        // }

    }
}