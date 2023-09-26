using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using lunchBlazor.Shared.Models;
using lunchBlazor.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;
using Blazored.LocalStorage;

namespace lunchBlazor.Client.Services.MppFormService
{
    public class MppFormService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        public GetDatasViewModel<MppForm> MppForms { get; set; } = new GetDatasViewModel<MppForm>();
        public MppForm MppForm { get; set; } = new MppForm();

        public MppFormService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }
        private async Task SetAuthorizationHeader()
        {
            var token = await _localStorage.GetItemAsync<string>("accessToken");
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task LoadMppForm(SieveModel sieveModel)
        {
            await SetAuthorizationHeader();
            MppForms = await _http.GetFromJsonAsync<GetDatasViewModel<MppForm>>($"api/MppForm?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetMppFormById(SieveModel sieveModel)
        {
           await SetAuthorizationHeader();
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<MppForm>>($"api/MppForm?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            MppForm = result.Items[0];
        }

        public async Task<string> CreateMppForm()
        {
            await SetAuthorizationHeader();
            var result = await _http.PostAsJsonAsync("api/MppForm","");
            var responseData = await result.Content.ReadFromJsonAsync<string>();
            return responseData;
        }
        public async Task<HttpResponseMessage> UpdateMppForm(string id, MppForm MppForm)
        {
            await SetAuthorizationHeader();
            var result = await _http.PutAsJsonAsync($"api/MppForm/{id}", MppForm);
            return result;
        }
        public async Task<HttpResponseMessage> DeleteMppForm(string id)
        {
            await SetAuthorizationHeader();
            var result = await _http.DeleteAsync($"api/MppForm/{id}");
            return result;
        }

    }
}