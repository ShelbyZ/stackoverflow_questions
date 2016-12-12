using System.Runtime.Serialization;

namespace DataContracts.DataContract
{
    [DataContract]
    public class MyObject2 : BaseObject
    {
        [DataMember(Name = "values")]
        public ValuesCollectionObject Values { get; set; }
    }
}
