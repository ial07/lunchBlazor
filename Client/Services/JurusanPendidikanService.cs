using System.Net.Http.Json;
using man_power_planning.Shared.Models;
using man_power_planning.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace man_power_planning.Client.Services.JurusanPendidikanService
{
    public class JurusanPendidikanService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<JurusanPendidikan> JurusanPendidikans { get; set; } = new GetDatasViewModel<JurusanPendidikan>();
        public JurusanPendidikan JurusanPendidikan { get; set; } = new JurusanPendidikan();

        public JurusanPendidikanService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadJurusanPendidikan(SieveModel sieveModel)
        {
            JurusanPendidikans = await _http.GetFromJsonAsync<GetDatasViewModel<JurusanPendidikan>>($"api/JurusanPendidikan?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetJurusanPendidikanById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<JurusanPendidikan>>($"api/JurusanPendidikan?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            JurusanPendidikan = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreateJurusanPendidikan(JurusanPendidikan JurusanPendidikan)
        {
            var result = await _http.PostAsJsonAsync("api/JurusanPendidikan", JurusanPendidikan);
            return result;
        }
        public async Task<HttpResponseMessage> UpdateJurusanPendidikan(string id, JurusanPendidikan JurusanPendidikan)
        {
            var result = await _http.PutAsJsonAsync($"api/JurusanPendidikan/{id}", JurusanPendidikan);
            return result;
        }
        public async Task<HttpResponseMessage> DeleteJurusanPendidikan(string id)
        {
            var result = await _http.DeleteAsync($"api/JurusanPendidikan/{id}");
            return result;
        }

    }
}