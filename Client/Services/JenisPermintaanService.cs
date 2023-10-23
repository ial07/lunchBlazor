using System.Net.Http.Json;
using man_power_planning.Shared.Models;
using man_power_planning.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace man_power_planning.Client.Services.JenisPermintaanService
{
    public class JenisPermintaanService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<JenisPermintaan> JenisPermintaans { get; set; } = new GetDatasViewModel<JenisPermintaan>();
        public JenisPermintaan JenisPermintaan { get; set; } = new JenisPermintaan();

        public JenisPermintaanService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadJenisPermintaan(SieveModel sieveModel)
        {
            JenisPermintaans = await _http.GetFromJsonAsync<GetDatasViewModel<JenisPermintaan>>($"api/JenisPermintaan?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetJenisPermintaanById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<JenisPermintaan>>($"api/JenisPermintaan?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            JenisPermintaan = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreateJenisPermintaan(JenisPermintaan JenisPermintaan)
        {
            var result = await _http.PostAsJsonAsync("api/JenisPermintaan", JenisPermintaan);
            return result;
        }
        public async Task<HttpResponseMessage> UpdateJenisPermintaan(string id, JenisPermintaan JenisPermintaan)
        {
            var result = await _http.PutAsJsonAsync($"api/JenisPermintaan/{id}", JenisPermintaan);
            return result;
        }
        public async Task<HttpResponseMessage> DeleteJenisPermintaan(string id)
        {
            var result = await _http.DeleteAsync($"api/JenisPermintaan/{id}");
            return result;
        }

    }
}