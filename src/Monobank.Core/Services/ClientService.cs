using Monobank.Core.Extensions;
using Monobank.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Monobank.Core.Services
{
    public class ClientService
    {
        private const string ClientInfoEndpoint = "personal/client-info";
        private const string StatementEndpoint = "personal/statement";
        private const string WebhookEndpoint = "personal/webhook";
        private const string TokenHeader = "X-Token";
        private const int RequestLimit = 60; // seconds
        private const int MaxStatementRange = 2682000; // 31 day + 1 hour
        private readonly HttpClient _httpClient;
        private DateTime _previousRequestTimestamp = DateTime.UtcNow.AddSeconds(-RequestLimit);

        public ClientService(HttpClient client, string token)
        {
            _httpClient = client;
            _httpClient.DefaultRequestHeaders.Add(TokenHeader, token);
        }

        public async Task<UserInfo?> GetClientInfoAsync()
        {
            var uri = new Uri(ClientInfoEndpoint, UriKind.Relative);
            var response = await _httpClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var error = JsonSerializer.Deserialize<Error>(responseString);
                throw new Exception(error!.Description);
            }
            
            return JsonSerializer.Deserialize<UserInfo>(responseString);
        }

        public async Task<ICollection<Statement>> GetStatementsAsync(DateTime from, DateTime to, string account = "0")
        {
            if (to.ToUnixTime() - from.ToUnixTime() >= MaxStatementRange)
            {
                throw new Exception("Time range exceeded. Difference between 'from' and 'to' should be less than 31 day + 1 hour.");
            }

            if ((DateTime.UtcNow - _previousRequestTimestamp).TotalSeconds <= RequestLimit)
            {
                throw new Exception($"Request limit exceeded. Only 1 request per {RequestLimit} seconds allowed.");
            }

            var uri = new Uri($"{StatementEndpoint}/{account}/{from.ToUnixTime()}/{to.ToUnixTime()}", UriKind.Relative);
            var response = await _httpClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var error = JsonSerializer.Deserialize<Error>(responseString);
                throw new Exception(error!.Description);
            }
            _previousRequestTimestamp = DateTime.UtcNow;
            return JsonSerializer.Deserialize<ICollection<Statement>>(responseString) ?? [];
        }

        public async Task<bool> SetWebhookAsync(string url)
        {
            // create body containing webhook url
            var body = JsonSerializer.Serialize(new { webHookUrl = url });
            // uri to call
            var uri = new Uri(WebhookEndpoint, UriKind.Relative);
            // set webhook
            var response = await _httpClient.PostAsync(uri, new StringContent(body));

            return response.IsSuccessStatusCode;
        }
    }
}