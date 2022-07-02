using GenericTaskRunner.Class;
using GenericTaskRunner.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTaskRunner.Controllers
{
    public class Configuration
    {
        public static void CreateConfigFile(string path = "")
        {
            path = GetCurrentDirectory(path);

            IConfigurationFile config = new ConfigurationFile();

            var json = JsonConvert.SerializeObject(config);           

            File.WriteAllText(path + "\\config.json", json);
        }

        public static bool ConfigFileExists(string path = "")
        {
            path = GetCurrentDirectory(path);

            return File.Exists(path + "\\config.json");
        }

        public static IConfigurationFile GetConfig(string path = "")
        {
            path = GetCurrentDirectory(path);          

            if (!ConfigFileExists(path))
            {
                CreateConfigFile(path);
            }

            var file = File.ReadAllText(path + "\\config.json");

            return JsonConvert.DeserializeObject<ConfigurationFile>(file);
        }

        private static string GetCurrentDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                path = Directory.GetCurrentDirectory();
            }

            return path;
        }

    }
}
