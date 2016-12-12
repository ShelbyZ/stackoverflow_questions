using DataContracts.DataContract;
using System.IO;
using System.Runtime.Serialization.Json;

namespace DataContracts.Serialization
{
    public static class Extensions
    {
        public static T FromBytes<T>(this byte[] bytes, bool simpleDictionary, bool surrogate)
            where T : Resource
        {
            var serializer = CreateSerializer<T>(simpleDictionary, surrogate);
            using (var stream = new MemoryStream(bytes))
            {
                return serializer.ReadObject(stream) as T;
            }
        }

        public static byte[] ToBytes<T>(this T obj, bool simpleDictionary, bool surrogate)
            where T : Resource
        {
            var serializer = CreateSerializer<T>(simpleDictionary, surrogate);
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);
                return stream.ToArray();
            }
        }

        private static DataContractJsonSerializer CreateSerializer<T>(bool simpleDictionary, bool surrogate)
            where T : Resource
        {
            var serializerSettings = new DataContractJsonSerializerSettings();

            if (simpleDictionary)
            {
                serializerSettings.UseSimpleDictionaryFormat = true;
            }

            if (surrogate)
            {
                serializerSettings.DataContractSurrogate = new ResourceSurrogate();
            }

            return new DataContractJsonSerializer(typeof(T), serializerSettings);
        }
    }
}
