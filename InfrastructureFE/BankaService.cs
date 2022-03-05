using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;
using FrontEndDomain.ListViewConfiguration;

namespace InfrastructureFE
{
    public class BankaService : IBankaService
    {
        private readonly HttpClient _httpClient;

        public BankaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Banka>> VratiBanke()
        {
            HttpResponseMessage? response = await _httpClient.GetAsync(UrlStrings.BankaUrl);
            IEnumerable<Banka> banke = await HttpUtilities.Deserialize<IEnumerable<Banka>>(response);

            return banke;
        }
    }
}
