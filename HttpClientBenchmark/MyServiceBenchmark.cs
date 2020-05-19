using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientBenchmark
{
    [MemoryDiagnoser]
    public class MyServiceBenchmark
    {
        private readonly MyService _service;

        public MyServiceBenchmark()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient();
            var services = serviceCollection.BuildServiceProvider();
            var factory = services.GetRequiredService<IHttpClientFactory>();
            _service = new MyService(factory);
        }

        [Benchmark]
        public async Task<string> TestReadingWebContent()
        {
            return await _service.ReadWebsiteContent().ConfigureAwait(false);
        }

        [Benchmark]
        public async Task<List<Photo>> TestReadingWebContentString()
        {
            return await _service.ReadWebsiteContentUsingString().ConfigureAwait(false);
        }

        [Benchmark]
        public async ValueTask<List<Photo>> TestReadingWebContentStream()
        {
            return await _service.ReadWebsiteContentUsingStream().ConfigureAwait(false);
        }
    }
}