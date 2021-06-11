using ApplicationCore.Models.Characters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ApplicationCore.Services
{
    public class SerializationService<T>
    {
        public JsonSerializerOptions SerializerOptions { get; set; }

        public SerializationService()
        {
            SerializerOptions = new JsonSerializerOptions();
        }
        public SerializationService(JsonSerializerOptions jsonSerializerOptions)
        {
            SerializerOptions = jsonSerializerOptions;
        }
        public void SerializeToFile(T obj,string path, string fileName)
        {
            using (FileStream fstream = new FileStream($"{path}\\{fileName}.json", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(JsonSerializer.Serialize<T>(obj, new JsonSerializerOptions { WriteIndented = true }));
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }
        }
        public string Serialize(T obj)
        {
            return JsonSerializer.Serialize<T>(obj, new JsonSerializerOptions { WriteIndented = true });
        }
        public T DeserializeFromFile(string path, string fileName)
        {
            string textFromFile;
            using (FileStream fstream = File.OpenRead($"{path}\\{fileName}.json"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);

                textFromFile = System.Text.Encoding.Default.GetString(array);
            }
            return JsonSerializer.Deserialize<T>(textFromFile);
        }
        public T Deserialize(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
