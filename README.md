# CallRestApiBenchmark
To run a benchmark for calling REST Api using BenchmarkDotnet.
Dataset is from free JSONPlaceholder:
https://jsonplaceholder.typicode.com/photos

## Scenarios
* Read REST Api json response as a string
* Read REST Api json resposnse as a string and deserialize to a collection of objects
* Read REST Api json resposnse as a stream and deserialize to a collection of objects

## Prerequisites
[.Net Core 3.1 SDK](https://download.visualstudio.microsoft.com/download/pr/73718445-e2bd-40b7-b698-e8a9ac65f4e5/0816570f697c4e8f1b53ecfb33eaed7f/dotnet-sdk-3.1.300-win-x64.exe)

## How to run:
```
dotnet build -c Release
dotnet run --project .\HttpClientBenchmark\HttpClientBenchmark.csproj -c Release
```

## Results
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.836 (1909/November2018Update/19H2)
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.300
  [Host]     : .NET Core 3.1.4 (CoreCLR 4.700.20.20201, CoreFX 4.700.20.22101), X64 RyuJIT
  DefaultJob : .NET Core 3.1.4 (CoreCLR 4.700.20.20201, CoreFX 4.700.20.22101), X64 RyuJIT


```
|                      Method |     Mean |   Error |   StdDev |   Median |     Gen 0 |     Gen 1 |     Gen 2 | Allocated |
|---------------------------- |---------:|--------:|---------:|---------:|----------:|----------:|----------:|----------:|
|       TestReadingWebContent | 285.0 ms | 3.46 ms |  2.89 ms | 283.4 ms |         - |         - |         - |   5.76 MB |
| TestReadingWebContentString | 299.6 ms | 5.91 ms | 13.23 ms | 293.5 ms | 1000.0000 | 1000.0000 | 1000.0000 |   7.33 MB |
| TestReadingWebContentStream | 298.8 ms | 5.92 ms | 13.25 ms | 292.4 ms |         - |         - |         - |   4.25 MB |