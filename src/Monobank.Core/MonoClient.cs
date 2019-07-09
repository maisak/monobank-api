using Monobank.Core.Services;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Monobank.Core
{
    public class MonoClient
    {
        private const string BaseApiUrl = "https://api.monobank.ua/";
        private const string ResponseMediaType = "application/json";

        public CurrencyService Currency { get; }
        public ClientService Client { get; }
        
        public MonoClient(string token = "")
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ResponseMediaType));
            httpClient.BaseAddress = new Uri(BaseApiUrl);

            Currency = new CurrencyService(httpClient);
            Client = new ClientService(httpClient, token);
        }
    }
}
