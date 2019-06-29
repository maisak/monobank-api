using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using ISO._4217;
using Monobank.Core.Extensions;

namespace Monobank.Core.Models
{
    [DataContract]
    public class Statement
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "time")]
        public long TimeInSeconds { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "mcc")]
        public int MCC { get; set; }

        [DataMember(Name = "hold")]
        public bool IsHold { get; set; }

        [DataMember(Name = "amount")]
        public long Amount { get; set; }

        [DataMember(Name = "operationAmount")]
        public long OperationAmount { get; set; }

        [DataMember(Name = "currencyCode")]
        public string CurrencyCode { get; set; }

        [DataMember(Name = "commissionRate")]
        public long ComissionRate { get; set; }

        [DataMember(Name = "cashbackAmount")]
        public long CashbackAmount { get; set; }

        [DataMember(Name = "balance")]
        public long Balance { get; set; }

        #region Custom properties

        public string CurrencyName => CurrencyCodesResolver.GetCodeByNumber(CurrencyCode);

        public DateTime Time => TimeInSeconds.ToDateTime();

        #endregion
    }
}
