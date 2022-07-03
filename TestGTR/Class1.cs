using GenericTaskRunner.Interfaces;

namespace TestGTR
{
    public class Teste : IExtension
    {
        public List<HelpCommand> HelpCommands => new List<HelpCommand>()
        {
            new HelpCommand()
            {
                Description = "Calcule valores",                         
                Name = "calcule",
                Shortcut= "calc"                
            }
        };

        public dynamic Run(string[] args)
        {
            Console.WriteLine("Teste");
            return null;
        }       
    }
}