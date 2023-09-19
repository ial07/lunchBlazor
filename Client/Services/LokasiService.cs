using System.Net.Http.Json;
using lunchBlazor.Shared.Models;
using lunchBlazor.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace lunchBlazor.Client.Services.LokasiService
{
    public class LokasiService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<Lokasi> Lokasies { get; set; } = new GetDatasViewModel<Lokasi>();
        public Lokasi Lokasi { get; set; } = new Lokasi();

        public LokasiService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadLokasi(SieveModel sieveModel)
        {
            Lokasies = await _http.GetFromJsonAsync<GetDatasViewModel<Lokasi>>($"api/Lokasi?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetLokasiById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<Lokasi>>($"api/Lokasi?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            Lokasi = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreateLokasi(Lokasi Lokasi)
        {
            var result = await _http.PostAsJsonAsync("api/Lokasi", Lokasi);
            return result;
        }
        public async Task<HttpResponseMessage> UpdateLokasi(string id, Lokasi Lokasi)
        {
            var result = await _http.PutAsJsonAsync($"api/Lokasi/{id}", Lokasi);
            return result;
        }
        public async Task<HttpResponseMessage> DeleteLokasi(string id)
        {
            var result = await _http.DeleteAsync($"api/Lokasi/{id}");
            return result;
        }

    }
}