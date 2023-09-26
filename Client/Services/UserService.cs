using System.Net.Http.Json;
using lunchBlazor.Shared.Models;
using lunchBlazor.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace lunchBlazor.Client.Services.UserService
{
    public class UserService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<User> Users { get; set; } = new GetDatasViewModel<User>();
        public User User { get; set; } = new User();

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadUser(SieveModel sieveModel)
        {
            Users = await _http.GetFromJsonAsync<GetDatasViewModel<User>>($"api/User?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetUserById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<User>>($"api/User?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            User = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreateUser(User User)
        {
            var result = await _http.PostAsJsonAsync("api/User", User);
            return result;
        }
        public async Task<HttpResponseMessage> UpdateUser(string id, User User)
        {
            var result = await _http.PutAsJsonAsync($"api/User/{id}", User);
            return result;
        }
        public async Task<HttpResponseMessage> DeleteUser(string id)
        {
            var result = await _http.DeleteAsync($"api/User/{id}");
            return result;
        }

    }
}