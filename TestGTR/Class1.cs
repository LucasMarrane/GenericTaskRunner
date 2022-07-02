using GenericTaskRunner.Interfaces;

namespace TestGTR
{
    public class Teste : IExtension
    {
        public string[] HelpCommands => new string[] {"teste - sassa lele"};

        public void Run(string[] args)
        {
            Console.WriteLine("Teste");
        }
    }
}