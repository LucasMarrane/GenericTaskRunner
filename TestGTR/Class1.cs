using GenericTaskRunner.Interfaces;

namespace TestGTR
{
    public class Teste : IExtension
    {

        public List<HelpCommand> HelpCommands => new List<HelpCommand>()
        {
            new HelpCommand()
            {
                Description = "Inicializa o teste",
                Name = "teste",
                Shortcut= "t"
            },
            new HelpCommand()
            {
                Description = "Calcule valores",                         
                Name = "calcule",
                Shortcut= "calc"                
            }
        };

        public string AppName => "teste";

        public dynamic Run(string[] args)
        {
            Console.WriteLine("Teste");
            return null;
        }       
    }
}