using System.Net.Http.Json;
using man_power_planning.Shared.Models;
using man_power_planning.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace man_power_planning.Client.Services.PendidikanService
{
    public class PendidikanService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<Pendidikan> Pendidikans { get; set; } = new GetDatasViewModel<Pendidikan>();
        public Pendidikan Pendidikan { get; set; } = new Pendidikan();

        public PendidikanService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadPendidikan(SieveModel sieveModel)
        {
            Pendidikans = await _http.GetFromJsonAsync<GetDatasViewModel<Pendidikan>>($"api/Pendidikan?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetPendidikanById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<Pendidikan>>($"api/Pendidikan?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            Pendidikan = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreatePendidikan(Pendidikan Pendidikan)
        {
            var result = await _http.PostAsJsonAsync("api/Pendidikan", Pendidikan);
            return result;
        }
        public async Task<HttpResponseMessage> UpdatePendidikan(string id, Pendidikan Pendidikan)
        {
            var result = await _http.PutAsJsonAsync($"api/Pendidikan/{id}", Pendidikan);
            return result;
        }
        public async Task<HttpResponseMessage> DeletePendidikan(string id)
        {
            var result = await _http.DeleteAsync($"api/Pendidikan/{id}");
            return result;
        }

    }
}