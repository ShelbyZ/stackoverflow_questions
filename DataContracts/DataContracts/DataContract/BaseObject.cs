using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataContracts.DataContract
{
    [DataContract]
    public class BaseObject : Resource
    {
        public IDictionary<string, object> extra_data;

        public void SetExtraData(KeyValuePair<string, object> item)
        {
            if (extra_data == null)
            {
                extra_data = new Dictionary<string, object>();
            }

            extra_data.Add(item);
        }
    }
}
