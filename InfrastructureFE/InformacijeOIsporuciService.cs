using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;
using FrontEndDomain.ListViewConfiguration;

namespace InfrastructureFE
{
    public class InformacijeOIsporuciService : IInformacijeOIsporuciService
    {
        private readonly HttpClient _httpClient;

        public InformacijeOIsporuciService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<InformacijeOIsporuci>> VratiInformacijeOIsporuci()
        {
            HttpResponseMessage? response = await _httpClient.GetAsync(UrlStrings.InformacijeOIsporuciUrl);
            ListViewModel<InformacijeOIsporuci>? listView = await HttpUtilities.Deserialize<ListViewModel<InformacijeOIsporuci>>(response);

            return listView.Data;
        }
    }
}
