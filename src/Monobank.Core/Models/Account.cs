using ISO._4217;
using System.Text.Json.Serialization;

namespace Monobank.Core.Models
{
    public class Account
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("balance")]
        public long Balance { get; set; }

        [JsonPropertyName("creditLimit")]
        public long CreditLimit { get; set; }

        [JsonPropertyName("currencyCode")]
        public int CurrencyCode { get; set; }

        [JsonPropertyName("cashbackType")]
        public string CashbackType { get; set; }

        #region Custom properties

        public string CurrencyName => CurrencyCodesResolver.GetCodeByNumber(CurrencyCode);

        #endregion
    }
}
