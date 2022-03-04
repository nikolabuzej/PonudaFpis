using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;
using FrontEndDomain.ListViewConfiguration;

namespace InfrastructureFE
{
    public class ProizvodService : IProizvodService
    {
        private readonly HttpClient _httpClient;

        public ProizvodService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ListViewModel<Proizvod>> VratiProizvode()
        {
            var httpResponse = await _httpClient.GetAsync(UrlStrings.ProizvodUrl);

            var reponse = await HttpUtilities.Deserialize<ListViewModel<Proizvod>>(httpResponse);

            return reponse;
        }
    }
}