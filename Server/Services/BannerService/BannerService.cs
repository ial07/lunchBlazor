using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace lunchBlazor.Server.Services.BannerService
{
    public class BannerService : IBannerService
    {
        private readonly AppDbContext _AppDbContext;
        public BannerService(AppDbContext AppDbContext)
        {
            _AppDbContext = AppDbContext;
        }


        public async Task<List<Banner>> GetBanners()
        {
            return await _AppDbContext.Banner.ToListAsync();
        }
    }
}