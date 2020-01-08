using System.Text.Json.Serialization;

namespace Monobank.Core.Models
{
    public class WebHookModel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("data")]
        public WebHookData Data { get; set; }
    }

    public class WebHookData
    {
        [JsonPropertyName("account")]
        public string Account { get; set; }
        [JsonPropertyName("statementItem")]
        public Statement StatementItem { get; set; }
    }
}
