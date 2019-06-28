using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Monobank.Core.Models;
using Newtonsoft.Json;

namespace Monobank.Core
{
    public class MonoClient
    {
        private const string BaseApiUrl = "https://api.monobank.ua/";
        private const string CurrencyEndpoint = "bank/currency";
        private const string ResponseMediaType = "application/json";
        private readonly HttpClient _httpClient;

        public MonoClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ResponseMediaType));
        }

        public async Task<ICollection<CurrencyInfo>> GetCurrencies()
        {
            var uri = new Uri($"{BaseApiUrl}{CurrencyEndpoint}");
            var response = await _httpClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<CurrencyInfo>>(responseString);
        }
    }
}
