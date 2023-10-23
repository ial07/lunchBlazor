using System.Net.Http.Json;
using man_power_planning.Shared.Models;
using man_power_planning.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace man_power_planning.Client.Services.PosisiService
{
    public class PosisiService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<Posisi> Posisies { get; set; } = new GetDatasViewModel<Posisi>();
        public Posisi Posisi { get; set; } = new Posisi();

        public PosisiService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadPosisi(SieveModel sieveModel)
        {
            Posisies = await _http.GetFromJsonAsync<GetDatasViewModel<Posisi>>($"api/Posisi?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetPosisiById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<Posisi>>($"api/Posisi?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            Posisi = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreatePosisi(Posisi Posisi)
        {
            var result = await _http.PostAsJsonAsync("api/Posisi", Posisi);
            return result;
        }
        public async Task<HttpResponseMessage> UpdatePosisi(string id, Posisi Posisi)
        {
            var result = await _http.PutAsJsonAsync($"api/Posisi/{id}", Posisi);
            return result;
        }
        public async Task<HttpResponseMessage> DeletePosisi(string id)
        {
            var result = await _http.DeleteAsync($"api/Posisi/{id}");
            return result;
        }

    }
}