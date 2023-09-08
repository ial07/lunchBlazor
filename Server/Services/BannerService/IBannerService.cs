

using lunchBlazor.Shared.Models;

namespace lunchBlazor.Server.Services.BannerService
{
    public interface IBannerService
    {
        Task<List<Banner>> GetBanners();

    }
}