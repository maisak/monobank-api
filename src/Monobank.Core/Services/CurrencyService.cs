using Monobank.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Monobank.Core.Services
{
    public class CurrencyService(HttpClient client)
    {
        private const string CurrencyEndpoint = "bank/currency";

        public async Task<ICollection<CurrencyInfo>> GetCurrencies()
        {
            var uri = new Uri($"{CurrencyEndpoint}", UriKind.Relative);
            var response = await client.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var error = JsonSerializer.Deserialize<Error>(responseString);
                throw new Exception(error!.Description);
            }

            return JsonSerializer.Deserialize<ICollection<CurrencyInfo>>(responseString) ?? [];
        }
    }
}
