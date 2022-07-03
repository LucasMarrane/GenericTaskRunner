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
                var line = string.Empty;
                if (args.Length == 0)
                {

                    Console.WriteLine("type -h or --help to see available commands");

                    line = Console.ReadLine();

                    if (line != "-h" && line != "--help")
                        return;
                }
                var tasks = ExtensionLoader.GetExtensionLoaded();


                if (args.Contains("--help") || args.Contains("-h") || line == "-h" || line == "--help")
                {
                    var help = tasks.Select(t => t.HelpCommands).SelectMany(s => s);
                    foreach (var command in help)
                    {
                        Console.WriteLine(command.Name);
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