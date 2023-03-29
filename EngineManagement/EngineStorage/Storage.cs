using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utils;

namespace EngineStorage
{
    public class Storage : IStorage
    {
        private readonly string filePath;

        public Storage(IOptions<FileLocation> option)
        {
            filePath = option.Value.Path;
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
    }
}