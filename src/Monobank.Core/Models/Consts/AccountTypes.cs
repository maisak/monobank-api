using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Monobank.Core.Models.Consts
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum AccountTypes
    {
        [EnumMember(Value = "black")]
        Black = 1,

        [EnumMember(Value = "white")]
        White = 2,

        [EnumMember(Value = "platinum")]
        Platinum = 3,

        [EnumMember(Value = "iron")]
        Iron = 4,

        [EnumMember(Value = "fop")]
        FOP = 5,

        [EnumMember(Value = "yellow")]
        Yellow = 6,
        
        [EnumMember(Value = "eAid")]
        EAid = 7
    }
}
