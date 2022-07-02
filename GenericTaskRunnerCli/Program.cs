using GenericTaskRunner.Controllers;
using GenericTaskRunner.Interfaces;
using System.Reflection;

namespace GenericTaskRunnerCli
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Awesome Task Runner";
            Console.WriteLine(@"
                            
  ,---. ,--------.,------.  
 /  O  \'--.  .--'|  .--. ' 
|  .-.  |  |  |   |  '--'.' 
|  | |  |  |  |   |  |\  \  
`--' `--'  `--'   `--' '--' 
                            
");
            Console.WriteLine("Awesome Task Runner");
            
            try
            {
                if (args.Length == 0)
                {
                    
                    Console.WriteLine("type -h or --help to see available commands");
                   
                    Console.ReadKey();
                    return;
                }
                var config = Configuration.GetConfig();

                IEnumerable<IExtension> tasks = config.plugins.SelectMany(pluginPath =>
                {
                    Assembly pluginAssembly = ExtensionLoader.LoadPlugin(pluginPath);
                    return ExtensionLoader.CreateCommands(pluginAssembly);
                }).ToList();

                if (args.Contains("--help") || args.Contains("-h"))
                {
                    var help = tasks.Select(t => t.HelpCommands).SelectMany(s => s);
                    foreach (var command in help)
                    {
                        Console.WriteLine(command);
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}