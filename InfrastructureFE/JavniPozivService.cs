using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;
using FrontEndDomain.ListViewConfiguration;

namespace InfrastructureFE
{
    public class JavniPozivService : IJavniPozivService
    {
        private readonly HttpClient _httpClient;

        public JavniPozivService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<JavniPoziv>> VratiJavnePozive()
        {
            HttpResponseMessage? response = await _httpClient.GetAsync(UrlStrings.JavniPozivUrl);

            ListViewModel<JavniPoziv>? listView = await HttpUtilities.Deserialize<ListViewModel<JavniPoziv>>(response);

            return listView.Data;
        }
    }
}
