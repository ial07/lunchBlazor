using lunchBlazor.Client;
using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;
using lunchBlazor.Shared.Models;

namespace lunchBlazor.Client.helper
{
    public class GlobalService
    {
        private readonly ILocalStorageService _localStorage;

        public GlobalService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }


        [CascadingParameter]
        public AppState ApplicationState { get; set; }
        public async Task<bool> CheckLogin()
        {

            bool itemExists = await _localStorage.ContainKeyAsync("profile") && await _localStorage.ContainKeyAsync("accessToken"); ;


            if (itemExists)
            {
                ApplicationState.User = await _localStorage.GetItemAsync<User>("profile");
                ApplicationState.Token = await _localStorage.GetItemAsync<string>("accessToken");
                return true;
            }
            return false;
        }
    }
}
