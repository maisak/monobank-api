using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using ISO._4217;

namespace Monobank.Core.Models
{
    public class Account
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "balance")]
        public long Balance { get; set; }

        [DataMember(Name = "creditLimit")]
        public long CreditLimit { get; set; }

        [DataMember(Name = "currencyCode")]
        public string CurrencyCode { get; set; }

        [DataMember(Name = "cashbackType")]
        public string CashbackType { get; set; }

        #region Custom properties

        public string CurrencyName => CurrencyCodesResolver.GetCodeByNumber(CurrencyCode);

        #endregion
    }
}
