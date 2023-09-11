using System.Net.Http.Json;
using lunchBlazor.Shared.Models;
using lunchBlazor.Shared.ViewModels;

namespace lunchBlazor.Client.Services.BannerService
{
    public class BannerService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<Banner> Banners { get; set; } = new GetDatasViewModel<Banner>();

        public BannerService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadBanner(int page, int pageSize)
        {
            Banners = await _http.GetFromJsonAsync<GetDatasViewModel<Banner>>($"api/Banner?Page={page}&PageSize={pageSize}");

        }

    }
}