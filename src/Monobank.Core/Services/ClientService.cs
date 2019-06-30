using Monobank.Core.Extensions;
using Monobank.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Monobank.Core.Services
{
    public class ClientService
    {
        private const string ClientInfoEndpoint = "personal/client-info";
        private const string StatementEndpoint = "personal/statement";
        private const string TokenHeader = "X-Token";
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient client, string token)
        {
            _httpClient = client;
            _httpClient.DefaultRequestHeaders.Add(TokenHeader, token);
        }

        public async Task<ICollection<UserInfo>> GetClientInfo()
        {
            var uri = new Uri(ClientInfoEndpoint, UriKind.Relative);
            var response = await _httpClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<Error>(responseString);
                throw new Exception(error.Description);
            }
            return JsonConvert.DeserializeObject<ICollection<UserInfo>>(responseString);
        }

        public async Task<ICollection<Statement>> GetStatements(DateTime from, DateTime to, string account = "0")
        {
            var uri = new Uri($"{StatementEndpoint}/{account}/{from.ToUnixTime()}/{to.ToUnixTime()}", UriKind.Relative);
            var response = await _httpClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<Error>(responseString);
                throw new Exception(error.Description);
            }
            return JsonConvert.DeserializeObject<ICollection<Statement>>(responseString);
        }
    }
}
