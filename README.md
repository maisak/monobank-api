# [Monobank](https://www.monobank.ua) API library

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
