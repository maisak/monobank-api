using System.Runtime.Serialization;

namespace Monobank.Core.Models
{
    [DataContract]
    public class WebHookModel
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "data")]
        public WebHookData Data { get; set; }
    }

    public class WebHookData
    {
        [DataMember(Name = "account")]
        public string Account { get; set; }
        [DataMember(Name = "statementItem")]
        public Statement StatementItem { get; set; }
    }
}
