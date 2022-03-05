using FrontEnd.FrontEndDomain;
using FrontEndDomain.Abstractions;
using FrontEndDomain.ListViewConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ListViewModel<Banka>? listView = await HttpUtilities.Deserialize<ListViewModel<Banka>>(response);

            return listView.Data;
        }
    }
}
