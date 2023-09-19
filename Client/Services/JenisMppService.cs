using System.Net.Http.Json;
using lunchBlazor.Shared.Models;
using lunchBlazor.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace lunchBlazor.Client.Services.JenisMppService
{
    public class JenisMppService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<JenisMpp> JenisMpps { get; set; } = new GetDatasViewModel<JenisMpp>();
        public JenisMpp JenisMpp { get; set; } = new JenisMpp();

        public JenisMppService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadJenisMpp(SieveModel sieveModel)
        {
            JenisMpps = await _http.GetFromJsonAsync<GetDatasViewModel<JenisMpp>>($"api/JenisMpp?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetJenisMppById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<JenisMpp>>($"api/JenisMpp?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            JenisMpp = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreateJenisMpp(JenisMpp JenisMpp)
        {
            var result = await _http.PostAsJsonAsync("api/JenisMpp", JenisMpp);
            return result;
        }
        public async Task<HttpResponseMessage> UpdateJenisMpp(string id, JenisMpp JenisMpp)
        {
            var result = await _http.PutAsJsonAsync($"api/JenisMpp/{id}", JenisMpp);
            return result;
        }
        public async Task<HttpResponseMessage> DeleteJenisMpp(string id)
        {
            var result = await _http.DeleteAsync($"api/JenisMpp/{id}");
            return result;
        }

    }
}