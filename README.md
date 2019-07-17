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
static async Task Main(string[] args)
{
    var mono = new MonoClient("YOUR_TOKEN");
    var statements = await mono.Client.GetStatements(from: new DateTime(2019, 6, 1), 
                                                     to: new DateTime(2019, 6, 30));
}
```
#### Webhook
Allows to be notified when there are transactions on user account.

According to [documentation](https://api.monobank.ua/docs), you need a POST endpoint to listen to webhook and the same GET endpoint for backing services to check availability. If you set webhook at ```https:\\example.com\webhook\test``` url - you will actually need two endpoints:  
**GET     https:\\example.com\webhook\test**  
**POST    https:\\example.com\webhook\test**

```
static async Task Main(string[] args)
{
    var mono = new MonoClient("YOUR_TOKEN");
    bool success = await mono.Client.SetWebhook("https:\\example.com\webhook\test");
}
```
To check webhook url - query user information and refer to ```webHookUrl``` property:
```
static async Task Main(string[] args)
{
    var mono = new MonoClient("YOUR_TOKEN");
    var userInfo = await mono.Client.GetClientInfo();
    var webHookUrl = userInfo.WebHookUrl;
}
```
