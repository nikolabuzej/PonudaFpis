using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfrastructureFE
{
    public static class HttpUtilities
    {
        public static async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var json = await response.Content.ReadAsStreamAsync();
            T reponse = await JsonSerializer.DeserializeAsync<T>(json, options);

            return reponse;
        }
    }
}
