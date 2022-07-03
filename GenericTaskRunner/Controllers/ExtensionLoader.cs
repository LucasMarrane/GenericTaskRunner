using GenericTaskRunner.Interfaces;
using System.Reflection;

namespace GenericTaskRunner.Controllers
{
    public class ExtensionLoader
    {
        public static Assembly LoadPlugin(string relativePath)
        {
            var pluginLocation = relativePath;
            var loadContext = new ExtensionContext(pluginLocation);
            return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
        }
        public static IEnumerable<IExtension> CreateCommands(Assembly assembly)
        {
            int count = 0;
            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IExtension).IsAssignableFrom(type))
                {
                    IExtension? result = Activator.CreateInstance(type) as IExtension;
                    if (result != null)
                    {
                        count++;
                        yield
                        return result;
                    }
                }
            }
        }

        public static List<IExtension> GetExtensionLoaded()
        {
            var config = Configuration.GetConfig();

            List<IExtension> tasks = config.plugins.SelectMany(pluginPath =>
            {
                Assembly pluginAssembly = LoadPlugin(pluginPath);
                return CreateCommands(pluginAssembly);
            }).ToList();

            return tasks;
        }
    }
}
