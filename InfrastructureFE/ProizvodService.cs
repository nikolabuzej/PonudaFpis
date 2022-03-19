using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;

namespace InfrastructureFE
{
    public class ProizvodService : IProizvodService
    {
        private readonly HttpClient _httpClient;

        public ProizvodService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Proizvod>> VratiProizvode()
        {
            HttpResponseMessage httpResponse = await _httpClient.GetAsync(UrlStrings.ProizvodUrl);

            IEnumerable<Proizvod> reponse = await HttpUtilities.Deserialize<IEnumerable<Proizvod>>(httpResponse);

            return reponse;
        }
    }
}