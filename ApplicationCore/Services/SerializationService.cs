using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

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
                byte[] array = System.Text.Encoding.Default.GetBytes(Serialize(obj));
                fstream.Write(array, 0, array.Length);
            }
        }
        public string Serialize(T obj)
        {
            return JsonSerializer.Serialize<T>(obj, SerializerOptions);
        }
        public async Task SerializeToFileAsync(T obj, string path, string fileName)
        {
            using (FileStream fstream = new FileStream($"{path}\\{fileName}.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<T>(fstream,obj, SerializerOptions);
            }
            await Task.Delay(1000);
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
            return Deserialize(textFromFile);
        }
        public async Task<T> DeserializeFromFileAsync(string path, string fileName)
        {
            string textFromFile;
            T obj;
            using (FileStream fstream = File.OpenRead($"{path}\\{fileName}.json"))
            {
                obj = await JsonSerializer.DeserializeAsync<T>(fstream, SerializerOptions);
            }
            await Task.Delay(1000);
            return obj;
        }
        public T Deserialize(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
