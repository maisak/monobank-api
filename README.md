# [Monobank](https://www.monobank.ua) API library
[![NuGet version (Monobank.API.Core)](https://img.shields.io/nuget/v/Monobank.API.Core.svg?style=flat-square)](https://www.nuget.org/packages/Monobank.API.Core/)
## How to use:
Public API:
```
static async Task Main(string[] args)
{
    var mono = new MonoClient();
    var currencies = await mono.Currency.GetCurrencies();
}
```
Private API:
```
```
