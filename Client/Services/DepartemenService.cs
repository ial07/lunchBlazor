using System.Net.Http.Json;
using lunchBlazor.Shared.Models;
using lunchBlazor.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace lunchBlazor.Client.Services.DepartemenService
{
    public class DepartemenService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<Departemen> Departemens { get; set; } = new GetDatasViewModel<Departemen>();
        public Departemen Departemen { get; set; } = new Departemen();

        public DepartemenService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadDepartemen(SieveModel sieveModel)
        {
            Departemens = await _http.GetFromJsonAsync<GetDatasViewModel<Departemen>>($"api/Departemen?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetDepartemenById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<Departemen>>($"api/Departemen?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            Departemen = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreateDepartemen(Departemen departemen)
        {
            var result = await _http.PostAsJsonAsync("api/Departemen", departemen);
            return result;
        }
        public async Task<HttpResponseMessage> UpdateDepartemen(string id, Departemen departemen)
        {
            var result = await _http.PutAsJsonAsync($"api/Departemen/{id}", departemen);
            return result;
        }
        public async Task<HttpResponseMessage> DeleteDepartemen(string id)
        {
            var result = await _http.DeleteAsync($"api/Departemen/{id}");
            return result;
        }

    }
}