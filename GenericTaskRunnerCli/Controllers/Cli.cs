using GenericTaskRunner.Controllers;
using GenericTaskRunner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTaskRunnerCli.Controllers
{
    internal class Cli
    {
        private static List<IExtension> _extensions = ExtensionLoader.GetExtensionLoaded();
        public static void Initialize()
        {
            Console.Title = "Awesome Task Runner";
            Console.WriteLine($@"--------------------------------------------------------");
            Console.WriteLine(@"
                            
  ,---. ,--------.,------.  
 /  O  \'--.  .--'|  .--. ' 
|  .-.  |  |  |   |  '--'.' 
|  | |  |  |  |   |  |\  \  
`--' `--'  `--'   `--' '--' 
                            
");
            Console.WriteLine("Awesome Task Runner");
            Console.WriteLine($@"CLI version: {CliVersion} ");
            Console.WriteLine($@"--------------------------------------------------------");
            Console.WriteLine("\n");
        }

        public static void Help()
        {

            var help = _extensions.Select(t => new { t.HelpCommands, t.AppName });
            Console.WriteLine("--------------------- Command List ---------------------");
            foreach (var command in help)
            {
                Console.WriteLine($@" --app {command.AppName}");
                foreach (var extension in command.HelpCommands)
                    Console.WriteLine($@"  -{extension.Shortcut} | --{extension.Name}  => {extension.Description}");
                Console.WriteLine("");

            }
            Console.WriteLine("--------------------------------------------------------");
        }

        public static string CliVersion { get; } = "0.0.1-beta";

    }
}
