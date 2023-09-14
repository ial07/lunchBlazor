using System.Net.Http.Json;
using lunchBlazor.Shared.Models;
using lunchBlazor.Shared.ViewModels;
using Sieve.Models;

namespace lunchBlazor.Client.Services.DepartemenService
{
    public class DepartemenService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<Departemen> Departemens { get; set; } = new GetDatasViewModel<Departemen>();

        public DepartemenService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadDepartemen(SieveModel sieveModel)
        {
            Departemens = await _http.GetFromJsonAsync<GetDatasViewModel<Departemen>>($"api/Departemen?Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
        }

    }
}