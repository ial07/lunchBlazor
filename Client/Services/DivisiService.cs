using System.Net.Http.Json;
using lunchBlazor.Shared.Models;
using lunchBlazor.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace lunchBlazor.Client.Services.DivisiService
{
    public class DivisiService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<Divisi> Divisies { get; set; } = new GetDatasViewModel<Divisi>();
        public Divisi Divisi { get; set; } = new Divisi();

        public DivisiService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadDepartemen(SieveModel sieveModel)
        {
            Divisies = await _http.GetFromJsonAsync<GetDatasViewModel<Divisi>>($"api/Divisi?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetDepartemenById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<Divisi>>($"api/Divisi?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            Divisi = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreateDepartemen(Divisi Divisi)
        {
            var result = await _http.PostAsJsonAsync("api/Divisi", Divisi);
            return result;
        }
        public async Task<HttpResponseMessage> UpdateDepartemen(string id, Divisi Divisi)
        {
            var result = await _http.PutAsJsonAsync($"api/Divisi/{id}", Divisi);
            return result;
        }
        public async Task<HttpResponseMessage> DeleteDepartemen(string id)
        {
            var result = await _http.DeleteAsync($"api/Divisi/{id}");
            return result;
        }

    }
}