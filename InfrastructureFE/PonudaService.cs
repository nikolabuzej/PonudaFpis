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
    public class PonudaService : IPonudaService
    {
        private readonly HttpClient _httpClient;

        public PonudaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ListViewModel<Ponuda>> VratiPonude(int pageNumber = 1, int pageSize = 1)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add(nameof(pageNumber), pageNumber.ToString());
            parameters.Add(nameof(pageSize), pageSize.ToString());

            HttpResponseMessage response = await _httpClient.GetAsync(HttpUtilities.AppendQueryString(UrlStrings.PonudaUrl,parameters));

            ListViewModel<Ponuda> result = await HttpUtilities.Deserialize<ListViewModel<Ponuda>>(response);

            return result;
        }


    }
}
