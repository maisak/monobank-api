﻿using System.Runtime.Serialization;
using ISO._4217;

namespace Monobank.Core.Models
{
    public sealed class CurrencyInfo
    {
        [DataMember(Name = "currencyCodeA")]
        public string CurrencyCodeA { get; set; }

        [DataMember(Name = "currencyCodeB")]
        public string CurrencyCodeB { get; set; }

        [DataMember(Name = "date")]
        public ulong Date { get; set; }

        [DataMember(Name = "rateSell")]
        public float RateSell { get; set; }

        [DataMember(Name = "rateBuy")]
        public float RateBuy { get; set; }

        [DataMember(Name = "rateCross")]
        public float RateCross { get; set; }

        #region Custom properties

        public string CurrencyNameA => CurrencyCodesResolver.GetCodeByNumber(CurrencyCodeA);
        public string CurrencyNameB => CurrencyCodesResolver.GetCodeByNumber(CurrencyCodeB);

        #endregion
    }
}