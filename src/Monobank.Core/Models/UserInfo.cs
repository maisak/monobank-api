﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Monobank.Core.Models
{
    public class UserInfo
    {
        [JsonPropertyName("clientId")] 
        public string Id { get; set; } = string.Empty;
        
        [JsonPropertyName("name")] 
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("webHookUrl")] 
        public string? WebHookUrl { get; set; }

        [JsonPropertyName("accounts")] 
        public ICollection<Account> Accounts { get; set; } = [];
    }
}
