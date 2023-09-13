using System.Net.Http.Json;
using lunchBlazor.Shared.Models;
using lunchBlazor.Shared.ViewModels;
using Sieve.Models;

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

        public async Task LoadBanner(SieveModel sieveModel)
        {
            Banners = await _http.GetFromJsonAsync<GetDatasViewModel<Banner>>($"api/Banner?Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
        }

    }
}