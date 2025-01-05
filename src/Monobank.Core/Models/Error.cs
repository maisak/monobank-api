using System.Text.Json.Serialization;

namespace Monobank.Core.Models
{
    public class Error
    {
        [JsonPropertyName("errorDescription")] 
        public string Description { get; set; } = string.Empty;
    }
}
