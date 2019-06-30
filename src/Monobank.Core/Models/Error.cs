using System.Runtime.Serialization;

namespace Monobank.Core.Models
{
    [DataContract]
    public class Error
    {
        [DataMember(Name = "errorDescription")]
        public string Description { get; set; }
    }
}
