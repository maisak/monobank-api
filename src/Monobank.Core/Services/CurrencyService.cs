using Monobank.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Monobank.Core.Services
{
    public class CurrencyService
    {
        private const string CurrencyEndpoint = "bank/currency";
        private readonly HttpClient _httpClient;

        public CurrencyService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<ICollection<CurrencyInfo>> GetCurrencies()
        {
            var uri = new Uri($"{CurrencyEndpoint}", UriKind.Relative);
            var response = await _httpClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var error = JsonSerializer.Deserialize<Error>(responseString);
                throw new Exception(error.Description);
            }

            //var arr = JsonSerializer.Deserialize<CurrencyInfo[]>(responseString);
            //var enu = JsonSerializer.Deserialize<IEnumerable<CurrencyInfo>>(responseString);

            return JsonSerializer.Deserialize<ICollection<CurrencyInfo>>(responseString);
        }
    }
}
