using System.Net.Http.Json;
using lunchBlazor.Shared.Models;
using lunchBlazor.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace lunchBlazor.Client.Services.MppFormService
{
    public class MppFormService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<MppForm> MppForms { get; set; } = new GetDatasViewModel<MppForm>();
        public MppForm MppForm { get; set; } = new MppForm();

        public MppFormService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadMppForm(SieveModel sieveModel)
        {
            MppForms = await _http.GetFromJsonAsync<GetDatasViewModel<MppForm>>($"api/MppForm?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetMppFormById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<MppForm>>($"api/MppForm?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            MppForm = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreateMppForm(MppForm MppForm)
        {
            var result = await _http.PostAsJsonAsync("api/MppForm", MppForm);
            return result;
        }
        public async Task<HttpResponseMessage> UpdateMppForm(string id, MppForm MppForm)
        {
            var result = await _http.PutAsJsonAsync($"api/MppForm/{id}", MppForm);
            return result;
        }
        public async Task<HttpResponseMessage> DeleteMppForm(string id)
        {
            var result = await _http.DeleteAsync($"api/MppForm/{id}");
            return result;
        }

    }
}