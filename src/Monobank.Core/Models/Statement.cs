using ISO._4217;
using Monobank.Core.Extensions;
using System;
using System.Text.Json.Serialization;

namespace Monobank.Core.Models
{
    public class Statement
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("time")]
        public long TimeInSeconds { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

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

        [JsonPropertyName("comment")]
        public string Comment { get; set; } = string.Empty;

        [JsonPropertyName("receiptId")]
        public string ReceiptId { get; set; } = string.Empty;

        [JsonPropertyName("counterEdrpou")]
        public string CounterEdrpou { get; set; } = string.Empty;

        [JsonPropertyName("counterIban")]
        public string CounterIban { get; set; } = string.Empty;

        #region Custom properties

        public string CurrencyName => CurrencyCodesResolver.GetCodeByNumber(CurrencyCode);

        public DateTime Time => TimeInSeconds.ToDateTime();

        #endregion
    }
}
