using System;

namespace Quantum.Core;

public static class ObjectSerializer
{
    public static string Serialize(this object obj)
    {
        Check.That().ArgumentNotEmpty("Object", obj, "");

        return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
    }

    public static T Deserialize<T>(this string serializedObject) 
        => string.IsNullOrWhiteSpace(serializedObject)
            ? default
            : Newtonsoft.Json.JsonConvert.DeserializeObject<T>(serializedObject);

    public static object Deserialize(this string serializedObject ,Type type)
        => string.IsNullOrWhiteSpace(serializedObject)
            ? default
            : Newtonsoft.Json.JsonConvert.DeserializeObject(serializedObject, type);
}