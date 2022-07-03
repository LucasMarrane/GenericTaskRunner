using GenericTaskRunner.Controllers;
using GenericTaskRunner.Interfaces;
using GenericTaskRunnerCli.Controllers;
using System.Reflection;

namespace GenericTaskRunnerCli
{

    internal class Program
    {

        static void Main(string[] args)
        {
           if(args.Contains("--help") || args.Contains("-h"))
            {
                Cli.Initialize();
            }

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
              
                if (args.Contains("--help") || args.Contains("-h") || line == "-h" || line == "--help")
                {
                    Cli.Help();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}