using System.Net.Http.Json;
using man_power_planning.Shared.Models;
using man_power_planning.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace man_power_planning.Client.Services.SumberPemenuhanService
{
    public class SumberPemenuhanService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<SumberPemenuhan> SumberPemenuhans { get; set; } = new GetDatasViewModel<SumberPemenuhan>();
        public SumberPemenuhan SumberPemenuhan { get; set; } = new SumberPemenuhan();

        public SumberPemenuhanService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadSumberPemenuhan(SieveModel sieveModel)
        {
            SumberPemenuhans = await _http.GetFromJsonAsync<GetDatasViewModel<SumberPemenuhan>>($"api/SumberPemenuhan?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetSumberPemenuhanById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<SumberPemenuhan>>($"api/SumberPemenuhan?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            SumberPemenuhan = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreateSumberPemenuhan(SumberPemenuhan SumberPemenuhan)
        {
            var result = await _http.PostAsJsonAsync("api/SumberPemenuhan", SumberPemenuhan);
            return result;
        }
        public async Task<HttpResponseMessage> UpdateSumberPemenuhan(string id, SumberPemenuhan SumberPemenuhan)
        {
            var result = await _http.PutAsJsonAsync($"api/SumberPemenuhan/{id}", SumberPemenuhan);
            return result;
        }
        public async Task<HttpResponseMessage> DeleteSumberPemenuhan(string id)
        {
            var result = await _http.DeleteAsync($"api/SumberPemenuhan/{id}");
            return result;
        }

    }
}