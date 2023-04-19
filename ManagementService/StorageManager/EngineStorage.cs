using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace StorageManager
{
    public class EngineStorage : IEngineStorage, IEngineStorageAvl
    {
        private readonly string filePath;

        public EngineStorage(string path)
        {
            filePath = path;
        }
        public string GetEnginePath(string name)
        {
            string json = File.ReadAllText(filePath);
            return JObject.Parse(json)[name].ToString();
        }

        public Dictionary<string, string> GetEngines()
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public void AddEngine(string name, string path)
        {
            string json = File.ReadAllText(filePath);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);

            jsonObj[name] = path;

            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(filePath, output);
        }
        public void RemoveEngine(string name)
        {
            string json = File.ReadAllText(filePath);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);

            jsonObj.Remove(name);

            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(filePath, output);
        }

    }
}
