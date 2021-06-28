using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Monobank.Core.Models.Consts
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CashbackTypes
    {
        [EnumMember(Value = "")]
        None = 1,

        [EnumMember(Value = "UAH")]
        UAH = 2,

        [EnumMember(Value = "Miles")]
        Miles = 3
    }
}
