using DataContracts.DataContract;
using DataContracts.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts
{
    class Program
    {
        static int count = 1;

        static void Main(string[] args)
        {
            var json = @"{""1-invalid-name"":""value"",""values"":{""one"":""1"",""two"":""2""}}";
            var jsonBytes = Encoding.UTF8.GetBytes(json);

            Console.WriteLine("json: {0}", json);

            // test 1 - UseSimpleDictionaryFormat = false, DataContractSurrogate = null
            RunTest<MyObject>(jsonBytes, false, false);

            // test 2 - UseSimpleDictionaryFormat = true, DataContractSurrogate = null
            RunTest<MyObject>(jsonBytes, true, false);

            // test 3 - UseSimpleDictionaryFormat = false, DataContractSurrogate = non-null
            RunTest<MyObject>(jsonBytes, false, true);

            // test 4 - UseSimpleDictionaryFormat = true, DataContractSurrogate = non-null
            RunTest<MyObject>(jsonBytes, true, true);

            // test 5 - UseSimpleDictionaryFormat = false, DataContractSurrogate = null
            RunTest<MyObject2>(jsonBytes, false, false);

            // test 6 - UseSimpleDictionaryFormat = true, DataContractSurrogate = null
            RunTest<MyObject2>(jsonBytes, true, false);

            // test 7 - UseSimpleDictionaryFormat = false, DataContractSurrogate = non-null
            RunTest<MyObject2>(jsonBytes, false, true);

            // test 8 - UseSimpleDictionaryFormat = true, DataContractSurrogate = non-null
            RunTest<MyObject2>(jsonBytes, true, true);

            // test 9 - UseSimpleDictionaryFormat = false, DataContractSurrogate = null
            RunTest<MyObject3>(jsonBytes, false, false);

            // test 10 - UseSimpleDictionaryFormat = true, DataContractSurrogate = null
            RunTest<MyObject3>(jsonBytes, true, false);

            // test 11 - UseSimpleDictionaryFormat = false, DataContractSurrogate = non-null
            RunTest<MyObject3>(jsonBytes, false, true);

            // test 12 - UseSimpleDictionaryFormat = true, DataContractSurrogate = non-null
            RunTest<MyObject3>(jsonBytes, true, true);

            // test 13 - UseSimpleDictionaryFormat = false, DataContractSurrogate = null
            RunTest<MyObject4>(jsonBytes, false, false);

            // test 14 - UseSimpleDictionaryFormat = true, DataContractSurrogate = null
            RunTest<MyObject4>(jsonBytes, true, false);

            // test 15 - UseSimpleDictionaryFormat = false, DataContractSurrogate = non-null
            RunTest<MyObject4>(jsonBytes, false, true);

            // test 16 - UseSimpleDictionaryFormat = true, DataContractSurrogate = non-null
            RunTest<MyObject4>(jsonBytes, true, true);

            // test 17 - UseSimpleDictionaryFormat = false, DataContractSurrogate = null
            RunTest<MyObject5>(jsonBytes, false, false);

            // test 18 - UseSimpleDictionaryFormat = true, DataContractSurrogate = null
            RunTest<MyObject5>(jsonBytes, true, false);

            // test 19 - UseSimpleDictionaryFormat = false, DataContractSurrogate = non-null
            RunTest<MyObject5>(jsonBytes, false, true);

            // test 20 - UseSimpleDictionaryFormat = true, DataContractSurrogate = non-null
            RunTest<MyObject5>(jsonBytes, true, true);

            Console.ReadLine();
        }

        static void RunTest<T>(byte[] bytes, bool simpleDictionary, bool surrogate)
            where T : Resource
        {
            try
            {
                Console.WriteLine("Test #{0}", count++);
                var myObject = bytes.FromBytes<T>(simpleDictionary, surrogate);
                CheckObject(myObject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught Exception {0}", ex);
            }
        }

        static void CheckObject<T>(T obj)
            where T : Resource
        {
            CheckBaseObject(obj as BaseObject);

            if (typeof(T) == typeof(MyObject))
            {
                CheckMyObject(obj as MyObject);
            }
            else if (typeof(T) == typeof(MyObject2))
            {
                CheckMyObject2(obj as MyObject2);
            }
            else if (typeof(T) == typeof(MyObject3))
            {
                CheckMyObject3(obj as MyObject3);
            }
            else if (typeof(T) == typeof(MyObject4))
            {
                CheckMyObject4(obj as MyObject4);
            }
            else if (typeof(T) == typeof(MyObject5))
            {
                // do nothing as the values should be in extra_data
            }
        }

        static void CheckCollection(IDictionary<string, object> data, string name)
        {
            Console.WriteLine("{0}: ", name);
            if (data != null)
            {
                foreach (var item in data)
                {
                    Console.WriteLine("\t{0}: {1}, ", item.Key, item.Value);
                }
            }
        }

        static void CheckCollection(IDictionary<string, string> data, string name)
        {
            Console.WriteLine("{0}: ", name);
            if (data != null)
            {
                foreach (var item in data)
                {
                    Console.WriteLine("\t{0}: {1}, ", item.Key, item.Value);
                }
            }
        }

        static void CheckBaseObject(BaseObject baseObject)
        {
            CheckCollection(baseObject.extra_data, "extra_data");
        }

        static void CheckMyObject(MyObject obj)
        {
            if (obj != null)
            {
                Console.WriteLine("values: ");
                if (obj.Values != null)
                {
                    Console.WriteLine("\tone: {0}", obj.Values.One);
                    Console.WriteLine("\ttwo: {0}", obj.Values.Two);
                }
            }
        }

        static void CheckMyObject2(MyObject2 obj)
        {
            if (obj != null)
            {
                CheckCollection(obj.Values, "values");
            }
        }

        static void CheckMyObject3(MyObject3 obj)
        {
            if (obj != null)
            {
                CheckCollection(obj.Values, "values");
            }
        }

        static void CheckMyObject4(MyObject4 obj)
        {
            if (obj != null)
            {
                Console.WriteLine("values: {0}", obj.Values != null ? obj.Values : string.Empty);
            }
        }
    }
}
