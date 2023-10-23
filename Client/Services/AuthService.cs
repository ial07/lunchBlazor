using Blazored.LocalStorage;
using man_power_planning.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace man_power_planning.Client.Services.AuthService
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        [CascadingParameter]
        public AppState ApplicationState { get; set; } = new AppState();
        public AuthViewModel AuthReponse { get; set; } = new AuthViewModel();

        public AuthService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        public async Task<bool> Login(UserForm login)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("api/auth/login", login);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadFromJsonAsync<AuthViewModel>();
                    if (response != null)
                    {
                        AuthReponse.data = response.data;
                        AuthReponse.accessToken = response.accessToken;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the request.
                Console.WriteLine($"Error: {ex.Message}");
            }

            return false;
        }


        public async Task<bool> CheckLogin()
        {

            bool itemExists = await _localStorage.ContainKeyAsync("profile") && await _localStorage.ContainKeyAsync("accessToken"); ;

            if (itemExists)
            {
                ApplicationState.User = await _localStorage.GetItemAsync<Users>("profile");
                ApplicationState.Token = await _localStorage.GetItemAsync<string>("accessToken");
                return true;
            }

            return false;
        }

    }
}
