using ISO._4217;
using Monobank.Core.Extensions;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Monobank.Core.Models
{
    public class Statement
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("time")]
        public long TimeInSeconds { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("mcc")]
        public int MerchantCategoryCode { get; set; }

        [JsonPropertyName("hold")]
        public bool IsHold { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("operationAmount")]
        public long OperationAmount { get; set; }

        [JsonPropertyName("currencyCode")]
        public int CurrencyCode { get; set; }

        [JsonPropertyName("commissionRate")]
        public long ComissionRate { get; set; }

        [JsonPropertyName("cashbackAmount")]
        public long CashbackAmount { get; set; }

        [JsonPropertyName("balance")]
        public long Balance { get; set; }

        #region Custom properties

        public string CurrencyName => CurrencyCodesResolver.GetCodeByNumber(CurrencyCode);

        public DateTime Time => TimeInSeconds.ToDateTime();

        #endregion
    }
}
