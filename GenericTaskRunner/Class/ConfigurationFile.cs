using GenericTaskRunner.Interfaces;

namespace GenericTaskRunner.Class
{
    public class ConfigurationFile : IConfigurationFile
    {
        public List<string> plugins { get; set; }  = new List<string>();
    }
}
