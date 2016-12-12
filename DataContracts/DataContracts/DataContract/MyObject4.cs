using System.Runtime.Serialization;

namespace DataContracts.DataContract
{
    [DataContract]
    public class MyObject4 : BaseObject
    {
        [DataMember(Name = "values")]
        public string Values { get; set; }
    }
}
