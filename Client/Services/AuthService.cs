using System.Net.Http.Json;

namespace lunchBlazor.Client.Services.AuthService
{
    public class AuthService
    {
        private readonly HttpClient _http;
        public AuthViewModel AuthReponse { get; set; } = new AuthViewModel();

        public AuthService(HttpClient http)
        {
            _http = http;
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

    }
}
