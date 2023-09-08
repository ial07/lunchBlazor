using lunchBlazor.Shared.Models;

namespace lunchBlazor.Client.Services.BannerService
{
    interface IBannerService
    {
        List<Banner> Banners { get; set; }
        Task LoadBanner();
    }
}