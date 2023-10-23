using System.Net.Http.Json;
using man_power_planning.Shared.Models;
using man_power_planning.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace man_power_planning.Client.Services.StatusService
{
    public class StatusService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<Status> Statuses { get; set; } = new GetDatasViewModel<Status>();
        public Status Status { get; set; } = new Status();

        public StatusService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadStatus(SieveModel sieveModel)
        {
            Statuses = await _http.GetFromJsonAsync<GetDatasViewModel<Status>>($"api/Status?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetStatusById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<Status>>($"api/Status?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            Status = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreateStatus(Status Status)
        {
            var result = await _http.PostAsJsonAsync("api/Status", Status);
            return result;
        }
        public async Task<HttpResponseMessage> UpdateStatus(string id, Status Status)
        {
            var result = await _http.PutAsJsonAsync($"api/Status/{id}", Status);
            return result;
        }
        public async Task<HttpResponseMessage> DeleteStatus(string id)
        {
            var result = await _http.DeleteAsync($"api/Status/{id}");
            return result;
        }

    }
}