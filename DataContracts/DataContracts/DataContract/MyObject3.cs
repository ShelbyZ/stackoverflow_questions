using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataContracts.DataContract
{
    [DataContract]
    public class MyObject3 : BaseObject
    {
        [DataMember(Name = "values")]
        public IDictionary<string, string> Values { get; set; }
    }
}
