using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using man_power_planning.Shared.Models;
using man_power_planning.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;
using Blazored.LocalStorage;
using System.Net;

namespace man_power_planning.Client.Services.MppFormService
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

        public async Task<string> CreateMppFormA1()
        {
            await SetAuthorizationHeader();
            var result = await _http.PostAsJsonAsync("api/MppForm/A1", "");
            if (result.IsSuccessStatusCode)
            {
                var responseData = await result.Content.ReadFromJsonAsync<string>();
                return responseData;
            }
            else if (result.StatusCode == HttpStatusCode.Unauthorized) // Check for 401 Unauthorized
            {
                await _localStorage.RemoveItemAsync("accessToken");
                await _localStorage.RemoveItemAsync("profile");
                return "Unauthorized";
            }
            else
            {
                return "HTTP Error: " + result.StatusCode.ToString();
            }
        }
        public async Task<string> CreateMppFormB1()
        {
            await SetAuthorizationHeader();
            var result = await _http.PostAsJsonAsync("api/MppForm/B1", "");
            if (result.IsSuccessStatusCode)
            {
                var responseData = await result.Content.ReadFromJsonAsync<string>();
                return responseData;
            }
            else if (result.StatusCode == HttpStatusCode.Unauthorized) // Check for 401 Unauthorized
            {
                await _localStorage.RemoveItemAsync("accessToken");
                await _localStorage.RemoveItemAsync("profile");
                return "Unauthorized";
            }
            else
            {
                return "HTTP Error: " + result.StatusCode.ToString();
            }
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