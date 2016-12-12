using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataContracts.DataContract
{
    [CollectionDataContract]
    public class ValuesCollectionObject : Dictionary<string, string>
    {
    }
}
