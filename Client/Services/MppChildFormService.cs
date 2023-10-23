using System.Net.Http.Json;
using man_power_planning.Shared.Models;
using man_power_planning.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Sieve.Models;

namespace man_power_planning.Client.Services.MppChildFormService
{
    public class MppChildFormService
    {
        private readonly HttpClient _http;
        public GetDatasViewModel<MppChildForm> MppChildForms { get; set; } = new GetDatasViewModel<MppChildForm>();
        public MppChildForm MppChildForm { get; set; } = new MppChildForm();

        public MppChildFormService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadMppChildForm(SieveModel sieveModel)
        {
            MppChildForms = await _http.GetFromJsonAsync<GetDatasViewModel<MppChildForm>>($"api/MppChildForm?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}&Sorts=-created");
        }

        public async Task GetMppChildFormById(SieveModel sieveModel)
        {
            var result = await _http.GetFromJsonAsync<GetDatasViewModel<MppChildForm>>($"api/MppChildForm?Filters={sieveModel.Filters}&Page={sieveModel.Page}&PageSize={sieveModel.PageSize}");
            MppChildForm = result.Items[0];
        }

        public async Task<HttpResponseMessage> CreateMppChildForm(MppChildForm MppChildForm)
        {
            var result = await _http.PostAsJsonAsync("api/MppChildForm", MppChildForm);
            return result;
        }
        public async Task<HttpResponseMessage> UpdateMppChildForm(string id, MppChildForm MppChildForm)
        {
            var result = await _http.PutAsJsonAsync($"api/MppChildForm/{id}", MppChildForm);
            return result;
        }
        public async Task<HttpResponseMessage> DeleteMppChildForm(string id)
        {
            var result = await _http.DeleteAsync($"api/MppChildForm/{id}");
            return result;
        }

    }
}