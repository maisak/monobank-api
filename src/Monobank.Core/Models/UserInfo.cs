using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Monobank.Core.Models
{
    [DataContract]
    public class UserInfo
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "webHookUrl")]
        public string WebHookUrl { get; set; }

        [DataMember(Name = "accounts")]
        public ICollection<Account> Accounts { get; set; }
    }
}
