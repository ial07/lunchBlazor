using System.Net.Http.Json;
using lunchBlazor.Shared.Models;

namespace lunchBlazor.Client.Services.BannerService
{
    public class BannerService : IBannerService
    {
        private readonly HttpClient _http;
        public List<Banner> Banners { get; set; } = new List<Banner>();

        public BannerService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadBanner()
        {
            Banners = await _http.GetFromJsonAsync<List<Banner>>("api/Banner");
        }
    }
}