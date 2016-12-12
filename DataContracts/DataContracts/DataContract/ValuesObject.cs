using System.Runtime.Serialization;

namespace DataContracts.DataContract
{
    [DataContract]
    public class ValuesObject : Resource
    {
        [DataMember(Name = "one")]
        public string One { get; set; }

        [DataMember(Name = "two")]
        public string Two { get; set; }
    }
}
