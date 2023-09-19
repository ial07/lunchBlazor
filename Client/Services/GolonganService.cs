using System.Net.Http.Json;
using lunchBlazor.Shared.Models;
using lunchBlazor.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace lunchBlazor.Client.Services.GolonganService
{
    public class GolonganService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<Golongan> Golongans { get; set; } = new GetDatasViewModel<Golongan>();
        public Golongan Golongan { get; set; } = new Golongan();

        public GolonganService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadGolongan(SieveModel sieveModel)
        {
            Golongans = await _http.GetFromJsonAsync<GetDatasViewModel<Golongan>>($"api/Golongan?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetGolonganById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<Golongan>>($"api/Golongan?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            Golongan = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreateGolongan(Golongan Golongan)
        {
            var result = await _http.PostAsJsonAsync("api/Golongan", Golongan);
            return result;
        }
        public async Task<HttpResponseMessage> UpdateGolongan(string id, Golongan Golongan)
        {
            var result = await _http.PutAsJsonAsync($"api/Golongan/{id}", Golongan);
            return result;
        }
        public async Task<HttpResponseMessage> DeleteGolongan(string id)
        {
            var result = await _http.DeleteAsync($"api/Golongan/{id}");
            return result;
        }

    }
}