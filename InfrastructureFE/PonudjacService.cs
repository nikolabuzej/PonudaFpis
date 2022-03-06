using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;

namespace InfrastructureFE
{
    public class PonudjacService : IPonudjacService
    {
        private readonly HttpClient _httpClient;

        public PonudjacService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Ponudjac>> VratiPonudjace()
        {
            HttpResponseMessage? response = await _httpClient.GetAsync(UrlStrings.PonudjacUrl);
            IEnumerable<Ponudjac> ponudjaci = await HttpUtilities.Deserialize<IEnumerable<Ponudjac>>(response);

            return ponudjaci;
        }
    }
}
