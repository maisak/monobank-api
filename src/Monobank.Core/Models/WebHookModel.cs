using System.Text.Json.Serialization;

namespace Monobank.Core.Models
{
    public class WebHookModel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("data")] 
        public WebHookData Data { get; set; } = null!;
    }

    public class WebHookData
    {
        [JsonPropertyName("account")]
        public string Account { get; set; } = string.Empty;
        
        [JsonPropertyName("statementItem")]
        public Statement StatementItem { get; set; } = null!;
    }
}
