using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClientBenchmark
{
    public class MyService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> ReadWebsiteContent()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/photos");

            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            else
            {
                return $"StatusCode: {response.StatusCode}";
            }
        }

        public async Task<List<Photo>> ReadWebsiteContentUsingString()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/photos");

            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<List<Photo>>(content);
        }

        public async ValueTask<List<Photo>> ReadWebsiteContentUsingStream()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/photos");

            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<List<Photo>>(stream).ConfigureAwait(false);
        }
    }
}