using System.Runtime.Serialization;

namespace DataContracts.DataContract
{
    [DataContract]
    public class MyObject : BaseObject
    {
        [DataMember(Name = "values")]
        public ValuesObject Values { get; set; }
    }
}
