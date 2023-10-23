using man_power_planning.Client;
using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;
using man_power_planning.Shared.Models;

namespace man_power_planning.Client.helper
{
    public class GlobalService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly AppState _ApplicationState;

        public GlobalService(ILocalStorageService localStorage, AppState ApplicationState)
        {
            _localStorage = localStorage;
            _ApplicationState = ApplicationState;
        }


        public async Task<bool> CheckLogin()
        {

            bool itemExists = await _localStorage.ContainKeyAsync("profile") && await _localStorage.ContainKeyAsync("accessToken"); ;


            if (itemExists)
            {
                // var token = await _localStorage.GetItemAsync<string>("accessToken");
                // var user = await _localStorage.GetItemAsync<User>("profile");
                // _ApplicationState.Token = token;
                // _ApplicationState.User = user;
                return true;
            }
            return false;
        }
    }
}
