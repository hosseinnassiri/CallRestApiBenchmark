using BenchmarkDotNet.Running;
using Microsoft.Extensions.Hosting;
using System;

namespace HttpClientBenchmark
{
    internal static class Program
    {
        //public static async Task<int> Main(string[] args)
        //{
        //    var builder = new HostBuilder()
        //        .ConfigureServices((hostContext, services) =>
        //        {
        //            services.AddHttpClient();
        //            services.AddTransient<MyService>();
        //        }).UseConsoleLifetime();

        //    var host = builder.Build();

        //    using (var serviceScope = host.Services.CreateScope())
        //    {
        //        var services = serviceScope.ServiceProvider;

        //        var myService = services.GetRequiredService<MyService>();
        //        var result = await myService.ReadWebsiteContentUsingStream().ConfigureAwait(false);

        //        Console.WriteLine(result.ToString());
        //    }
        //    return 0;
        //}

        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<MyServiceBenchmark>();
        }
    }
}