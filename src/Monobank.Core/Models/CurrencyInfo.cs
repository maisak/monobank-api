using ISO._4217;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Monobank.Core.Models
{
    public sealed class CurrencyInfo
    {
        [JsonPropertyName("currencyCodeA")]
        public int CurrencyCodeA { get; set; }

        [JsonPropertyName("currencyCodeB")]
        public int CurrencyCodeB { get; set; }

        [JsonPropertyName("date")]
        public long Date { get; set; }

        [JsonPropertyName("rateSell")]
        public float RateSell { get; set; }

        [JsonPropertyName("rateBuy")]
        public float RateBuy { get; set; }

        [JsonPropertyName("rateCross")]
        public float RateCross { get; set; }

        #region Custom properties

        public string CurrencyNameA => CurrencyCodesResolver.GetCodeByNumber(CurrencyCodeA);
        public string CurrencyNameB => CurrencyCodesResolver.GetCodeByNumber(CurrencyCodeB);

        #endregion
    }
}
