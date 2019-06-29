# [Monobank](https://www.monobank.ua) API library
[![NuGet version (Monobank.API.Core)](https://img.shields.io/nuget/v/Monobank.API.Core.svg?style=flat-square)](https://www.nuget.org/packages/Monobank.API.Core/)

This library is a wrapper on Monobank open API. To use it you will need to get a personal token at https://api.monobank.ua/.
## How to use:
### Public API:
Available without a personal token. Just intitialize MonoClient with it's default constructor.
```
static async Task Main(string[] args)
{
    var mono = new MonoClient();
    var currencies = await mono.Currency.GetCurrencies();
}
```
### Client API:
Available only with a personal token.
#### User information 

```
static async Task Main(string[] args)
{
    var mono = new MonoClient("YOUR_TOKEN");
    var userInfo = await mono.Client.GetClientInfo();
}
```
#### Statements
```
```
