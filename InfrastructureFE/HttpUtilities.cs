using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            options.Converters.Add(new JsonStringEnumConverter());
            var json = await response.Content.ReadAsStreamAsync();
            T reponse = await JsonSerializer.DeserializeAsync<T>(json, options);

            return reponse;
        }
        public static HttpContent CreateBody<T>(T payload)
        {
            var json = JsonSerializer.Serialize<T>(payload);

            var content =  new StringContent(json,Encoding.UTF8,"application/json");

            return content;
        }
        public static string AppendQueryString(string url,Dictionary<string,string> parameters)
        {
            bool startingQuestionMarkAdded = false;
            var sb = new StringBuilder();
            sb.Append(url);
            foreach (var parameter in parameters)
            {
                if (parameter.Value == null)
                {
                    continue;
                }

                sb.Append(startingQuestionMarkAdded ? '&' : '?');
                sb.Append(parameter.Key);
                sb.Append('=');
                sb.Append(parameter.Value);
                startingQuestionMarkAdded = true;
            }
            return sb.ToString();
        }
    }
}
