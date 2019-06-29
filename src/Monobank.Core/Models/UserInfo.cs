using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Monobank.Core.Models
{
    public class UserInfo
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "accounts")]
        public ICollection<Account> Accounts { get; set; }
    }
}
