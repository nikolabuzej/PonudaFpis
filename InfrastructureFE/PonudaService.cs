using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;
using FrontEndDomain.ListViewConfiguration;
using FrontEndDomain.Payloads;
using System.Net.Http.Json;

namespace InfrastructureFE
{
    public class PonudaService : IPonudaService
    {
        private readonly HttpClient _httpClient;

        public PonudaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Ponuda> AzurirajPonudu(Guid id, PonudaPayload payload)
        {
            var response = (await _httpClient.PutAsJsonAsync($"{UrlStrings.PonudaUrl}/{id}", payload)).EnsureSuccessStatusCode();

            return (await HttpUtilities.Deserialize<Ponuda>(response));
        }

        public async Task<Ponuda> KreirajPonudu(PonudaPayload payload)
        {
            var response = (await _httpClient.PostAsJsonAsync($"{UrlStrings.PonudaUrl}", payload)).EnsureSuccessStatusCode();

            return (await HttpUtilities.Deserialize<Ponuda>(response));
        }

        public async Task ObrisiPonudu(Guid id)
        {
            _ = (await _httpClient.DeleteAsync($"{UrlStrings.PonudaUrl}/{id}")).EnsureSuccessStatusCode();
        }

        public async Task<ListViewModel<Ponuda>> VratiPonude(int pageNumber = 1,
                                                             int pageSize = 2,
                                                             SortProperty sortProperty = SortProperty.DatumPristizanja,
                                                             SortOrder sortOrder = SortOrder.asc,
                                                             string searchText = "")
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add(nameof(pageNumber), pageNumber.ToString());
            parameters.Add(nameof(pageSize), pageSize.ToString());
            parameters.Add(nameof(sortProperty), sortProperty.ToString());
            parameters.Add(nameof(sortOrder), sortOrder.ToString());
            parameters.Add(nameof(searchText), searchText);
            HttpResponseMessage response = await _httpClient.GetAsync(HttpUtilities.AppendQueryString(UrlStrings.PonudaUrl, parameters));

            ListViewModel<Ponuda> result = await HttpUtilities.Deserialize<ListViewModel<Ponuda>>(response);

            return result;
        }

        public async Task<Ponuda> VratiPonudu(Guid id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{UrlStrings.PonudaUrl}/{id}");
            Ponuda ponuda = await HttpUtilities.Deserialize<Ponuda>(response);

            return ponuda;
        }
    }
}
