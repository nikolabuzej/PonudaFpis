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

            ListViewModel<Ponudjac>? listView = await HttpUtilities.Deserialize<ListViewModel<Ponudjac>>(response);

            return listView.Data;
        }
    }
}
