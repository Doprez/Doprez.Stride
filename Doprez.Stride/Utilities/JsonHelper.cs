using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Immolation.Core.Utilities
{
    public static class JsonHelper
    {
        private static readonly JsonSerializerOptions _options;

        static JsonHelper()
        {
            _options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
        }

        public static string SerializeJson<T>(T objectToSerialize)
        {
            return JsonSerializer.Serialize(objectToSerialize, _options);
        }

        public static T DeserializeJson<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, _options);
        }
        
        // Method that accepts a generic type T and a file name, and serializes an object of type T to a JSON string
        // and writes the JSON string to the specified file
        public static void WriteJsonToFile<T>(string fileName, T obj)
        {
            // Serialize the object to a JSON string
            string json = JsonSerializer.Serialize(obj, _options);

            // Write the JSON string to a file
            File.WriteAllText(fileName, json);
        }

        // Method that accepts a generic type T and a file name, reads a JSON string from the specified file,
        // and deserializes it back into an object of type T
        public static T ReadJsonFromFile<T>(string fileName)
        {
            // Read the JSON string from the file
            string jsonFromFile = File.ReadAllText(fileName);

            // Deserialize the JSON string back into an object of type T
            return JsonSerializer.Deserialize<T>(jsonFromFile, _options);
        }

    }
}
